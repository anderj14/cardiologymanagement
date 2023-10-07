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
    public class DiseaseHistoryController : ControllerBase
    {
        private readonly IGenericRepository<DiseaseHistory> _diseaseHistRepo;
        private readonly IMapper _mapper;

        public DiseaseHistoryController(IGenericRepository<DiseaseHistory> diseaseHistRepo, IMapper mapper)
        {
            _diseaseHistRepo = diseaseHistRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<DiseaseHistoryDto>>> GetDiseaseHistories()
        {
            var diseaseHistories = await _diseaseHistRepo.ListAllAsync();
            var diseaseHistoriesDtos = _mapper.Map<IReadOnlyList<DiseaseHistoryDto>>(diseaseHistories);

            return Ok(diseaseHistoriesDtos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DiseaseHistoryDto>> GetDiseaseHistory(int id)
        {
            var diseaseHistory = await _diseaseHistRepo.GetByIdAsync(id);
            var diseaseHistoryDto = _mapper.Map<DiseaseHistoryDto>(diseaseHistory);

            return Ok(diseaseHistoryDto);
        }

        [HttpGet("patient/{patientId}/diseasesHistories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<DiseaseHistoryDto>>> GetTreatmentsByPatientId(int patientId)
        {
            var spec = new DiseaseHistorySpecification(patientId);
            var diseasesHistories = await _diseaseHistRepo.ListAsync(spec);
            var diseasesHistoriesDtos = _mapper.Map<IReadOnlyList<DiseaseHistoryDto>>(diseasesHistories);

            return Ok(diseasesHistoriesDtos);
        }

        [HttpGet("patient/{patientId}/diseasesHistories/{diseaseHistoryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DiseaseHistoryDto>> GetTreatmentByPatientId(int patientId, int diseaseHistoryId)
        {
            var spec = new DiseaseHistorySpecification(patientId, diseaseHistoryId);
            var diseaseHistory = await _diseaseHistRepo.GetEntityWithSpec(spec);
            var diseaseHistoryDto = _mapper.Map<DiseaseHistoryDto>(diseaseHistory);

            return Ok(diseaseHistoryDto);
        }
    }
}

