using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HolterStudyController : ControllerBase
    {
        private readonly IGenericRepository<HolterStudy> _holterStudyRepo;
        private readonly IMapper _mapper;

        public HolterStudyController(IGenericRepository<HolterStudy> holterStudyRepo, IMapper mapper)
        {
            _holterStudyRepo = holterStudyRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<HolterStudyDto>>> GetHolterStudies(){
            var holterStudies = await _holterStudyRepo.ListAllAsync();
            var holterStudiesDtos = _mapper.Map<IReadOnlyList<HolterStudyDto>>(holterStudies);

            return Ok(holterStudiesDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HolterStudyDto>> GetHolterStudy(int id){
            var holterStudy = await _holterStudyRepo.GetByIdAsync(id);
            var holterStudyDto = _mapper.Map<HolterStudyDto>(holterStudy);

            return Ok(holterStudyDto);
        }
    }
}