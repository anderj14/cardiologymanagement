using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiagnosticController : ControllerBase
    {
        private readonly IDiagnosticRepository _repo;
        private readonly IMapper _mapper;

        public DiagnosticController(IDiagnosticRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<DiagnosticDto>>> GetDiagnostics(){
            var diagnostics = await _repo.GetDiagnosticsAsync();
            var DiagnosticsDto = _mapper.Map<List<DiagnosticDto>>(diagnostics);

            return Ok(DiagnosticsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DiagnosticDto>> GetDiagnostic(int id){
            var diagnostic = await _repo.GetDiagnosticAsync(id);
            var diagnosticDto = _mapper.Map<DiagnosticDto>(diagnostic);

            return Ok(diagnosticDto);
        }
    }
}