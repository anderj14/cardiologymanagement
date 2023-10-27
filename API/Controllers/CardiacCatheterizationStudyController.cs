
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CardiacCatheterizationStudyDto>> GetCardiacCatheterizationStudy(int id)
        {
            var cardiacCatheterizationStudy = await _carCathStudyRepo.GetByIdAsync(id);
            var cardiacCatheterizationStudyDto = _mapper.Map<CardiacCatheterizationStudyDto>(cardiacCatheterizationStudy);

            return Ok(cardiacCatheterizationStudyDto);
        }

        [HttpGet("patient/{patientId}/cardiacCathStudies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<CardiacCatheterizationStudyDto>>> GetCardiacCathStudiesByPatientId(int patientId)
        {
            var spec = new CardiacCatheterizationStudySpecification(patientId);
            var cardiacCatheterizationStudies = await _carCathStudyRepo.ListAsync(spec);
            var cardiacCatheterizationStudyDtos = _mapper.Map<IReadOnlyList<CardiacCatheterizationStudyDto>>(cardiacCatheterizationStudies);

            return Ok(cardiacCatheterizationStudyDtos);
        }

        [HttpGet("patient/{patientId}/cardiacCathStudies/{cardiacCathStudyId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CardiacCatheterizationStudyDto>> GetCardiacCathStudyIdByPatientId(
            int patientId, int cardiacCathStudyId)
        {
            var spec = new CardiacCatheterizationStudySpecification(patientId, cardiacCathStudyId);
            var cardiacCathStudy = await _carCathStudyRepo.GetEntityWithSpec(spec);
            var cardiacCathStudyDto = _mapper.Map<CardiacCatheterizationStudyDto>(cardiacCathStudy);

            return Ok(cardiacCathStudyDto);
        }

    }

}