using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EchocardiogramController : ControllerBase
    {
        private readonly IEchocardiogramRepository _repo;
        private readonly IMapper _mapper;

        public EchocardiogramController(IEchocardiogramRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<EchocardiogramDto>>> GetEchocardiograms()
        {
            var echocardiograms = await _repo.GetEchocardiogramsAsync();
            var echocardiogramsDtos = _mapper.Map<List<EchocardiogramDto>>(echocardiograms);

            return Ok(echocardiogramsDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EchocardiogramDto>> GetEchocardiogram(int id)
        {
            var echocardiogram = await _repo.GetEchocardiogramAsync(id);
            var echocardiogramDto = _mapper.Map<EchocardiogramDto>(echocardiogram);

            return Ok(echocardiogramDto);
        }
    }
}