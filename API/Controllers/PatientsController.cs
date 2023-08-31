using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IGenericRepository<Patient> _patientRepo;
        private readonly IMapper _mapper;

        public PatientsController(IGenericRepository<Patient> patientRepo, IMapper mapper)
        {
            _patientRepo = patientRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<PatientDto>>> GetPatients()
        {
            var spec = new PatientWithAllSpecification();

            var patients = await _patientRepo.ListAsync(spec);

            var patientDtos = _mapper.Map<IReadOnlyList<PatientDto>>(patients);

            return Ok(patientDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDto>> GetPatient(int id)
        {
            var spec = new PatientWithAllSpecification(id);

            var patient = await _patientRepo.GetEntityWithSpec(spec);

            var patientDto = _mapper.Map<PatientDto>(patient);

            return Ok(patientDto);
        }
    }
}