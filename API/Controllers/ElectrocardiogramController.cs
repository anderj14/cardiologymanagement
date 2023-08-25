using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ElectrocardiogramController : ControllerBase
    {
        private readonly IElectrocardiogramRepository _repo;
        private readonly IMapper _mapper;

        public ElectrocardiogramController(IElectrocardiogramRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ElectrocardiogramDto>>> GetElectrocardiograms()
        {
            var electrocardiograms = await _repo.GetElectrocardiogramsAsync();
            var electrocardiogramsDtos = _mapper.Map<List<ElectrocardiogramDto>>(electrocardiograms);

            return Ok(electrocardiogramsDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ElectrocardiogramDto>> GetElectrocardiogram(int id)
        {
            var electrocardiogram = await _repo.GetElectrocardiogramAsync(id);
            var electrocardiogramDto = _mapper.Map<ElectrocardiogramDto>(electrocardiogram);

            return Ok(electrocardiogramDto);
        }
    }
}