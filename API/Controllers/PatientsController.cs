using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository _repo;
        private readonly IMapper _mapper;

        public PatientsController(IPatientRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<PatientDto>>> GetPatients()
        {
            var patients = await _repo.GetPatientsAsync();

            var patientDtos = _mapper.Map<List<PatientDto>>(patients);

            return Ok(patientDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var patient = await _repo.GetPatientByIdAsync(id);

            return Ok(patient);
        }
    }
}