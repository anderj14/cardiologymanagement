using API.Errors;
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
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
    }
}