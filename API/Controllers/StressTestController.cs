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
    public class StressTestController : ControllerBase
    {
        private readonly IGenericRepository<StressTest> _stressTestRepo;
        private readonly IMapper _mapper;

        public StressTestController(IGenericRepository<StressTest> stressTestRepo, IMapper mapper)
        {
            _stressTestRepo = stressTestRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<StressTestDto>>> GetStressTests()
        {
            var stressTests = await _stressTestRepo.ListAllAsync();

            var stressTestsDtos = _mapper.Map<IReadOnlyList<StressTestDto>>(stressTests);

            return Ok(stressTestsDtos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StressTestDto>> GetStressTest(int id)
        {
            var stressTest = await _stressTestRepo.GetByIdAsync(id);

            var stressTestDto = _mapper.Map<StressTestDto>(stressTest);

            return Ok(stressTestDto);
        }

        [HttpGet("patient/{patientId}/stressTests")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<StressTestDto>>> GetStressTestsByPatientId(int patientId)
        {
            var spec = new StressTestSpecification(patientId);
            var stressTests = await _stressTestRepo.ListAsync(spec);
            var stressTestsDtos = _mapper.Map<IReadOnlyList<StressTestDto>>(stressTests);

            return Ok(stressTestsDtos);
        }

        [HttpGet("patient/{patientId}/stressTests/{stressTestId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<StressTestDto>>> GetStressTestByPatientId(int patientId, int stressTestId)
        {
            var spec = new StressTestSpecification(patientId, stressTestId);
            var stressTests = await _stressTestRepo.GetEntityWithSpec(spec);
            var stressTestsDtos = _mapper.Map<StressTestDto>(stressTests);

            return Ok(stressTestsDtos);
        }
    }
}