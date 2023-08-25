using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BloodTestController : ControllerBase
    {
        private readonly IBloodTestRepository _repo;
        private readonly IMapper _mapper;

        public BloodTestController(IBloodTestRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BloodTestDto>>> GetBloodTests()
        {
            var bloodTests = await _repo.GetBloodTestsAsync();
            var bloodTestsDtos = _mapper.Map<List<BloodTestDto>>(bloodTests);

            return Ok(bloodTestsDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BloodTestDto>> GetBloodTest(int id)
        {
            var bloodTest = await _repo.GetBloodTestAsync(id);
            var bloodTestDtos = _mapper.Map<BloodTestDto>(bloodTest);

            return Ok(bloodTestDtos);
        }
    }
}