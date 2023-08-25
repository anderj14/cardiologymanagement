using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiseaseHistoryController : ControllerBase
    {
        private readonly IDiseaseHistoryRepository _repo;
        private readonly IMapper _mapper;

        public DiseaseHistoryController(IDiseaseHistoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<DiseaseHistoryDto>>> GetDiseaseHistories()
        {
            var diseaseHistories = await _repo.GetDiseaseHistoriesAsync();
            var diseaseHistoriesDtos = _mapper.Map<List<DiseaseHistoryDto>>(diseaseHistories);

            return Ok(diseaseHistoriesDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DiseaseHistoryDto>> GetDiseaseHistory(int id)
        {
            var diseaseHistory = await _repo.GetDiseaseHistoryAsync(id);
            var diseaseHistoryDto = _mapper.Map<DiseaseHistoryDto>(diseaseHistory);

            return Ok(diseaseHistoryDto);
        }
    }
}