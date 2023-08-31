using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
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
        public async Task<ActionResult<TreatmentDto>> GetTreatment(int id)
        {
            var stressTest = await _treatmentRepo.GetByIdAsync(id);

            var stressTestDto = _mapper.Map<TreatmentDto>(stressTest);

            return Ok(stressTestDto);
        }
    }
}