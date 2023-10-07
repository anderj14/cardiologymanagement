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
    public class ElectrocardiogramController : ControllerBase
    {
        private readonly IGenericRepository<Electrocardiogram> _electroRepo;
        private readonly IMapper _mapper;

        public ElectrocardiogramController(IGenericRepository<Electrocardiogram> electroRepo, IMapper mapper)
        {
            _electroRepo = electroRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ElectrocardiogramDto>>> GetElectrocardiograms()
        {
            var electrocardiograms = await _electroRepo.ListAllAsync();
            var electrocardiogramsDtos = _mapper.Map<IReadOnlyList<ElectrocardiogramDto>>(electrocardiograms);

            return Ok(electrocardiogramsDtos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ElectrocardiogramDto>> GetElectrocardiogram(int id)
        {
            var electrocardiogram = await _electroRepo.GetByIdAsync(id);
            var electrocardiogramDto = _mapper.Map<ElectrocardiogramDto>(electrocardiogram);

            return Ok(electrocardiogramDto);
        }

        [HttpGet("patient/{patientId}/electrocardiograms")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<Electrocardiogram>>> GetElectrocardiogramsByPatientId(int patientId)
        {
            var spec = new ElectrocardiogramSpecification(patientId);
            var electrocardiograms = await _electroRepo.ListAsync(spec);
            var electrocardiogramsDtos = _mapper.Map<IReadOnlyList<ElectrocardiogramDto>>(electrocardiograms);

            return Ok(electrocardiogramsDtos);
        }

        [HttpGet("patient/{patientId}/electrocardiograms/{electrocardiogramId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Electrocardiogram>> GetElectrocardiogramByPatientId(int patientId, int electrocardiogramId)
        {
            var spec = new ElectrocardiogramSpecification(patientId, electrocardiogramId);
            var electrocardiogram = await _electroRepo.GetEntityWithSpec(spec);
            var electrocardiogramDto = _mapper.Map<ElectrocardiogramDto>(electrocardiogram);

            return Ok(electrocardiogramDto); 
        }
    }
}