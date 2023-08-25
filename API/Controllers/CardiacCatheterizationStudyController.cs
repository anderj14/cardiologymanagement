
using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardiacCatheterizationStudyController : ControllerBase
    {
        private readonly ICardiacCatheterizationStudyRepository _repo;
        private readonly IMapper _mapper;

        public CardiacCatheterizationStudyController(ICardiacCatheterizationStudyRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CardiacCatheterizationStudyDto>>> GetCardiacCatheterizationStudies()
        {
            var cardiacCatheterizationStudies = await _repo.GetCardiacCatheterizationStudiesAsync();
            var cardiacCatheterizationStudiesDto = _mapper.Map<List<CardiacCatheterizationStudyDto>>(cardiacCatheterizationStudies);

            return Ok(cardiacCatheterizationStudiesDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CardiacCatheterizationStudyDto>> GetCardiacCatheterizationStudy(int id)
        {
            var cardiacCatheterizationStudy = await _repo.GetCardiacCatheterizationStudyAsync(id);
            var cardiacCatheterizationStudyDto = _mapper.Map<CardiacCatheterizationStudyDto>(cardiacCatheterizationStudy);

            return Ok(cardiacCatheterizationStudyDto);
        }
    }
}