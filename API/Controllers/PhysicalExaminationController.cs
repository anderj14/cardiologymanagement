using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhysicalExaminationController : ControllerBase
    {
        private readonly IPhysicalExaminationRepository _repo;
        private readonly IMapper _mapper;

        public PhysicalExaminationController(IPhysicalExaminationRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<PhysicalExaminationDto>>> GetPhysicalExaminations()
        {
            var physicalExaminations = await _repo.GetPhysicalExaminationsAsync();

            var physicalExaminationsDtos = _mapper.Map<List<PhysicalExaminationDto>>(physicalExaminations);

            return Ok(physicalExaminationsDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PhysicalExaminationDto>> GetPhysicalExamination(int id)
        {
            var physicalExamination = await _repo.GetPhysicalExaminationAsync(id);

            var physicalExaminationDto = _mapper.Map<PhysicalExaminationDto>(physicalExamination);

            return Ok(physicalExaminationDto);
        }
    }
}