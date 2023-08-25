using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HolterStudyController : ControllerBase
    {
        private readonly IHolterStudyRepository _repo;
        private readonly IMapper _mapper;

        public HolterStudyController(IHolterStudyRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<HolterStudyDto>>> GetHolterStudies(){
            var holterStudies = await _repo.GetHolterStudiesAsync();
            var holterStudiesDtos = _mapper.Map<List<HolterStudyDto>>(holterStudies);

            return Ok(holterStudiesDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HolterStudyDto>> GetHolterStudy(int id){
            var holterStudy = await _repo.GetHolterStudyAsync(id);
            var holterStudyDto = _mapper.Map<HolterStudyDto>(holterStudy);

            return Ok(holterStudyDto);
        }
    }
}