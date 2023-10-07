using API.Errors;
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhysicalExaminationController : ControllerBase
    {
        private readonly IGenericRepository<PhysicalExamination> _physicalExamRepo;
        private readonly IMapper _mapper;

        public PhysicalExaminationController(IGenericRepository<PhysicalExamination> physicalExamRepo, IMapper mapper)
        {
            _physicalExamRepo = physicalExamRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<PhysicalExaminationDto>>> GetPhysicalExaminations()
        {
            var physicalExaminations = await _physicalExamRepo.ListAllAsync();

            var physicalExaminationsDtos = _mapper.Map<IReadOnlyList<PhysicalExaminationDto>>(physicalExaminations);

            return Ok(physicalExaminationsDtos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PhysicalExaminationDto>> GetPhysicalExamination(int id)
        {
            var physicalExamination = await _physicalExamRepo.GetByIdAsync(id);

            var physicalExaminationDto = _mapper.Map<PhysicalExaminationDto>(physicalExamination);

            return Ok(physicalExaminationDto);
        }

        [HttpGet("patient/{patientId}/physicalExaminations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<PhysicalExaminationDto>>> GetPhysicalExaminationsByPatientId(int patientId)
        {
            var spec = new PhysicalExaminationSpecification(patientId);
            var physicalExaminations = await _physicalExamRepo.ListAsync(spec);
            var physicalExaminationsDtos = _mapper.Map<IReadOnlyList<PhysicalExaminationDto>>(physicalExaminations);

            return Ok(physicalExaminationsDtos);
        }

        [HttpGet("patient/{patientId}/physicalExaminations/{physicalExaminationId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PhysicalExaminationDto>> GetPhysicalExaminationByPatientId(int patientId, int physicalExaminationId)
        {
            var spec = new PhysicalExaminationSpecification(patientId, physicalExaminationId);
            var physicalExamination = await _physicalExamRepo.GetEntityWithSpec(spec);
            var physicalExaminationDto = _mapper.Map<PhysicalExaminationDto>(physicalExamination);

            return Ok(physicalExaminationDto);
        }
    }
}