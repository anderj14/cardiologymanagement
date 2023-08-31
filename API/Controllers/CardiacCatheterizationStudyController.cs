
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardiacCatheterizationStudyController : ControllerBase
    {
        private readonly IGenericRepository<CardiacCatheterizationStudy> _carCathStudyRepo;
        private readonly IMapper _mapper;

        public CardiacCatheterizationStudyController(IGenericRepository<CardiacCatheterizationStudy> carCathStudyRepo, IMapper mapper)
        {
            _carCathStudyRepo = carCathStudyRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CardiacCatheterizationStudyDto>>> GetCardiacCatheterizationStudies()
        {
            var cardiacCatheterizationStudies = await _carCathStudyRepo.ListAllAsync();
            var cardiacCatheterizationStudiesDto = _mapper.Map<IReadOnlyList<CardiacCatheterizationStudyDto>>(cardiacCatheterizationStudies);

            return Ok(cardiacCatheterizationStudiesDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CardiacCatheterizationStudyDto>> GetCardiacCatheterizationStudy(int id)
        {
            var cardiacCatheterizationStudy = await _carCathStudyRepo.GetByIdAsync(id);
            var cardiacCatheterizationStudyDto = _mapper.Map<CardiacCatheterizationStudyDto>(cardiacCatheterizationStudy);

            return Ok(cardiacCatheterizationStudyDto);
        }
    }
}