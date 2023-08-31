using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiagnosticController : ControllerBase
    {
        private readonly IGenericRepository<Diagnostic> _diagnosticRepo;
        private readonly IMapper _mapper;

        public DiagnosticController(IGenericRepository<Diagnostic> diagnosticRepo, IMapper mapper)
        {
            _diagnosticRepo = diagnosticRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<DiagnosticDto>>> GetDiagnostics(){
            var diagnostics = await _diagnosticRepo.ListAllAsync();
            var DiagnosticsDto = _mapper.Map<IReadOnlyList<DiagnosticDto>>(diagnostics);

            return Ok(DiagnosticsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DiagnosticDto>> GetDiagnostic(int id){
            var diagnostic = await _diagnosticRepo.GetByIdAsync(id);
            var diagnosticDto = _mapper.Map<DiagnosticDto>(diagnostic);

            return Ok(diagnosticDto);
        }
    }
}