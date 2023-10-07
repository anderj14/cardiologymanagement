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
        public async Task<ActionResult<IReadOnlyList<HolterStudyDto>>> GetHolterStudies()
        {
            var holterStudies = await _holterStudyRepo.ListAllAsync();
            var holterStudiesDtos = _mapper.Map<IReadOnlyList<HolterStudyDto>>(holterStudies);

            return Ok(holterStudiesDtos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<HolterStudyDto>> GetHolterStudy(int id)
        {
            var holterStudy = await _holterStudyRepo.GetByIdAsync(id);
            var holterStudyDto = _mapper.Map<HolterStudyDto>(holterStudy);

            return Ok(holterStudyDto);
        }

        [HttpGet("patient/{patientId}/holterStudies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<HolterStudyDto>>> GetHolterStudiesByPatientId(int patientId)
        {
            var spec = new HolterStudySpecification(patientId);
            var holterStudies = await _holterStudyRepo.ListAsync(spec);
            var holterStudiesDtos = _mapper.Map<IReadOnlyList<HolterStudyDto>>(holterStudies);

            return Ok(holterStudiesDtos);
        }

        [HttpGet("patient/{patientId}/holterStudies/{holterStudyId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<HolterStudyDto>>> GetHolterStudyByPatientId(int patientId, int holterStudyId)
        {
            var spec = new HolterStudySpecification(patientId, holterStudyId);
            var holterStudy = await _holterStudyRepo.GetEntityWithSpec(spec);
            var holterStudyDto = _mapper.Map<HolterStudyDto>(holterStudy);

            return Ok(holterStudyDto);
        }
    }
}