using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicalHistoryController : ControllerBase
    {
        private readonly IMedicalHistoryRepository _repo;
        private readonly IMapper _mapper;

        public MedicalHistoryController(IMedicalHistoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<MedicalHistoryDto>>> GetMedicalHistories()
        {
            var medicalHistories = await _repo.GetMedicalHistoriesAsync();
            var medicalHistoriesDtos = _mapper.Map<List<MedicalHistoryDto>>(medicalHistories);

            return Ok(medicalHistoriesDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalHistoryDto>> GetMedicalHistory(int id)
        {
            var medicalHistory = await _repo.GetMedicalHistoryAsync(id);
            var medicalHistoryDto = _mapper.Map<MedicalHistoryDto>(medicalHistory);

            return Ok(medicalHistoryDto);
        }
    }
}