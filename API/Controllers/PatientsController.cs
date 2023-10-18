using API.Errors;
using API.Helper;
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PatientsController : BaseApiController
    {
        private readonly IGenericRepository<Patient> _patientRepo;
        private readonly IMapper _mapper;

        public PatientsController(IGenericRepository<Patient> patientRepo, IMapper mapper)
        {
            _patientRepo = patientRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<PatientDto>>> GetPatients(
            [FromQuery] PatientSpecParams patientParams)
        {
            var spec = new PatientWithAllSpecification(patientParams);

            var countSpec = new PatientWithFiltersForCountSpecification(patientParams);

            var totalItems = await _patientRepo.CountAsync(countSpec);

            var patients = await _patientRepo.ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<PatientDto>>(patients);

            return Ok(new Pagination<PatientDto>(patientParams.PageIndex,
            patientParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PatientDto>> GetPatient(int id)
        {
            var spec = new PatientWithAllSpecification(id);

            var patient = await _patientRepo.GetEntityWithSpec(spec);

            var patientDto = _mapper.Map<PatientDto>(patient);

            return Ok(patientDto);
        }
    }
}
