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
    public class TreatmentController : ControllerBase
    {
        private readonly IGenericRepository<Treatment> _treatmentRepo;
        private readonly IMapper _mapper;

        public TreatmentController(IGenericRepository<Treatment> treatmentRepo, IMapper mapper)
        {
            _treatmentRepo = treatmentRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<TreatmentDto>>> GetTreatments()
        {
            var treatments = await _treatmentRepo.ListAllAsync();

            var treatmentsDtos = _mapper.Map<IReadOnlyList<TreatmentDto>>(treatments);

            return Ok(treatmentsDtos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TreatmentDto>> GetTreatment(int id)
        {
            var stressTest = await _treatmentRepo.GetByIdAsync(id);

            var stressTestDto = _mapper.Map<TreatmentDto>(stressTest);

            return Ok(stressTestDto);
        }

        [HttpGet("patient/{patientId}/treatments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<TreatmentDto>>> GetTreatmentsByPatientId(int patientId)
        {
            var spec = new TreatmentSpecification(patientId);
            var treatments = await _treatmentRepo.ListAsync(spec);
            var treatmentsDtos = _mapper.Map<IReadOnlyList<TreatmentDto>>(treatments);

            return Ok(treatmentsDtos);
        }

        [HttpGet("patient/{patientId}/treatments/{treatmentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TreatmentDto>> GetTreatmentByPatientId(int patientId, int treatmentId)
        {
            var spec = new TreatmentSpecification(patientId, treatmentId);
            var treatment = await _treatmentRepo.GetEntityWithSpec(spec);
            var treatmentDto = _mapper.Map<TreatmentDto>(treatment);

            return Ok(treatmentDto);
        }
    }
}