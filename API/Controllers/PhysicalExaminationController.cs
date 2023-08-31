using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
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
        public async Task<ActionResult<PhysicalExaminationDto>> GetPhysicalExamination(int id)
        {
            var physicalExamination = await _physicalExamRepo.GetByIdAsync(id);

            var physicalExaminationDto = _mapper.Map<PhysicalExaminationDto>(physicalExamination);

            return Ok(physicalExaminationDto);
        }
    }
}