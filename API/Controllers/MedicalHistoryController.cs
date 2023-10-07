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
    public class MedicalHistoryController : ControllerBase
    {
        private readonly IGenericRepository<MedicalHistory> _medHistoryRepo;
        private readonly IMapper _mapper;

        public MedicalHistoryController(IGenericRepository<MedicalHistory> medHistoryRepo, IMapper mapper)
        {
            _medHistoryRepo = medHistoryRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<MedicalHistoryDto>>> GetMedicalHistories()
        {
            var medicalHistories = await _medHistoryRepo.ListAllAsync();
            var medicalHistoriesDtos = _mapper.Map<IReadOnlyList<MedicalHistoryDto>>(medicalHistories);

            return Ok(medicalHistoriesDtos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MedicalHistoryDto>> GetMedicalHistory(int id)
        {
            var medicalHistory = await _medHistoryRepo.GetByIdAsync(id);
            var medicalHistoryDto = _mapper.Map<MedicalHistoryDto>(medicalHistory);

            return Ok(medicalHistoryDto);
        }

        [HttpGet("patient/{patientId}/medicalHistories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<MedicalHistoryDto>>> GetMedicalHistoriesByPatientId(int patientId)
        {
            var spec = new MedicalHistorySpecification(patientId);
            var medicalHistories = await _medHistoryRepo.ListAsync(spec);
            var medicalHistoriesDtos = _mapper.Map<IReadOnlyList<MedicalHistoryDto>>(medicalHistories);

            return Ok(medicalHistoriesDtos);
        }

        [HttpGet("patient/{patientId}/medicalHistories/medicalHistoryId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MedicalHistoryDto>> GetMedicalHistoryByPatientId(int patientId, int medicalHistoryId)
        {
            var spec = new MedicalHistorySpecification(patientId, medicalHistoryId);
            var medicalHistory = await _medHistoryRepo.GetEntityWithSpec(spec);
            var medicalHistoryDto = _mapper.Map<MedicalHistoryDto>(medicalHistory);

            return Ok(medicalHistoryDto);
        }
    }
}