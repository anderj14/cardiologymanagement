using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StressTestController : ControllerBase
    {
        private readonly IGenericRepository<StressTest> _stressTestrepo;
        private readonly IMapper _mapper;

        public StressTestController(IGenericRepository<StressTest> stressTestrepo, IMapper mapper)
        {
            _stressTestrepo = stressTestrepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<StressTestDto>>> GetStressTests()
        {
            var stressTests = await _stressTestrepo.ListAllAsync();

            var stressTestsDtos = _mapper.Map<IReadOnlyList<StressTestDto>>(stressTests);

            return Ok(stressTestsDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StressTestDto>> GetStressTest(int id)
        {
            var stressTest = await _stressTestrepo.GetByIdAsync(id);

            var stressTestDto = _mapper.Map<StressTestDto>(stressTest);

            return Ok(stressTestDto);
        }
    }
}