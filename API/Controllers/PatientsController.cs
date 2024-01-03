using System.Security.Claims;
using API.Errors;
using API.Helper;
using AutoMapper;
using Core.Dtos;
using Core.Dtos.CreateDto;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin, Member")]
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
        [Authorize(Roles = "Admin, Member")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PatientDto>> GetPatient(int id)
        {
            var spec = new PatientWithAllSpecification(id);

            var patient = await _unitOfWork.Repository<Patient>().GetEntityWithSpec(spec);

            if (patient == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Patient, PatientDto>(patient);
        }

        [HttpPost]
        public async Task<ActionResult<Patient>> CreatePatient(PatientCreateDto patientToCreate)
        {
            var patient = _mapper.Map<PatientCreateDto, Patient>(patientToCreate);

            _unitOfWork.Repository<Patient>().Add(patient);

            var result = await _unitOfWork.Complete();

            if (result <= 0) return BadRequest(new ApiResponse(400, "Problem creating patient information"));

            return Ok(patient);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Patient>> UpdatePatient(int id, PatientCreateDto patientToUpdate)
        {
            var patient = await _unitOfWork.Repository<Patient>().GetByIdAsync(id);

            _mapper.Map(patientToUpdate, patient);
            _unitOfWork.Repository<Patient>().Update(patient);

            var result = await _unitOfWork.Complete();

            if (result <= 0) return BadRequest(new ApiResponse(400, "Problem updating patient information"));

            return Ok(patient);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePatient(int id)
        {
            var patient = await _unitOfWork.Repository<Patient>().GetByIdAsync(id);

            _unitOfWork.Repository<Patient>().Delete(patient);

            var result = await _unitOfWork.Complete();

            if (result <= 0) return BadRequest(new ApiResponse(400, "Problem updating patient information"));

            return Ok();
        }
    }
}
