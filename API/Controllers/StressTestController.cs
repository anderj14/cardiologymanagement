using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StressTestController : ControllerBase
    {
        private readonly IStressTestRepository _repo;
        private readonly IMapper _mapper;

        public StressTestController(IStressTestRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<StressTestDto>>> GetStressTests()
        {
            var stressTests = await _repo.GetStressTestsAsync();

            var stressTestsDtos = _mapper.Map<List<StressTestDto>>(stressTests);

            return Ok(stressTestsDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StressTestDto>> GetStressTest(int id)
        {
            var stressTest = await _repo.GetStressTestAsync(id);

            var stressTestDto = _mapper.Map<StressTestDto>(stressTest);

            return Ok(stressTestDto);
        }
    }
}