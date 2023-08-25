using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TreatmentController : ControllerBase
    {
        private readonly ITreatmentRepository _repo;
        private readonly IMapper _mapper;

        public TreatmentController(ITreatmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<TreatmentDto>>> GetTreatments()
        {
            var treatments = await _repo.GetTreatmentsAsync();

            var treatmentsDtos = _mapper.Map<List<TreatmentDto>>(treatments);

            return Ok(treatmentsDtos);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TreatmentDto>> GetTreatment(int id)
        {
            var stressTest = await _repo.GetTreatmentAsync(id);

            var stressTestDto = _mapper.Map<TreatmentDto>(stressTest);

            return Ok(stressTestDto);
        }
    }
}