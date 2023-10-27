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
    public class EchocardiogramController : ControllerBase
    {
        private readonly IGenericRepository<Echocardiogram> _echocardiogramRepo;
        private readonly IMapper _mapper;

        public EchocardiogramController(IGenericRepository<Echocardiogram> echocardiogramRepo, IMapper mapper)
        {
            _echocardiogramRepo = echocardiogramRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<EchocardiogramDto>>> GetEchocardiograms()
        {
            var echocardiograms = await _echocardiogramRepo.ListAllAsync();
            var echocardiogramsDtos = _mapper.Map<IReadOnlyList<EchocardiogramDto>>(echocardiograms);

            return Ok(echocardiogramsDtos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EchocardiogramDto>> GetEchocardiogram(int id)
        {
            var echocardiogram = await _echocardiogramRepo.GetByIdAsync(id);
            var echocardiogramDto = _mapper.Map<EchocardiogramDto>(echocardiogram);

            return Ok(echocardiogramDto);
        }

        [HttpGet("patient/{patientId}/echocardiograms")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<DiagnosticDto>>> GetEchocardiogramByPatientId(int patientId)
        {
            var spec = new EchocardiogramSpecification(patientId);
            var echocardiograms = await _echocardiogramRepo.ListAsync(spec);
            var echocardiogramDtos = _mapper.Map<IReadOnlyList<EchocardiogramDto>>(echocardiograms);

            return Ok(echocardiogramDtos);
        }

        [HttpGet("patient/{patientId}/echocardiograms/{echocardiogramId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EchocardiogramDto>> GetEchocardiogramByPatientId(
            int patientId, int echocardiogramId)
        {
            var spec = new EchocardiogramSpecification(patientId, echocardiogramId);
            var echocardiogram = await _echocardiogramRepo.GetEntityWithSpec(spec);
            var echocardiogramDto = _mapper.Map<EchocardiogramDto>(echocardiogram);

            return Ok(echocardiogramDto);
        }

    }
}