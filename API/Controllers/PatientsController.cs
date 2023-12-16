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
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PatientsController(IUnitOfWork unitOfwork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfwork;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<PatientDto>>> GetPatients(
            [FromQuery] PatientSpecParams patientParams)
        {
            var spec = new PatientWithAllSpecification(patientParams);

            var countSpec = new PatientWithFiltersForCountSpecification(patientParams);

            var totalItems = await _unitOfWork.Repository<Patient>().CountAsync(countSpec);

            var patients = await _unitOfWork.Repository<Patient>().ListAsync(spec);

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

            var patient = await _unitOfWork.Repository<Patient>().GetEntityWithSpec(spec);

            if (patient == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Patient, PatientDto>(patient);
        }
    }
}
