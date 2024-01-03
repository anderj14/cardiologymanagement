
using API.Errors;
using API.Helper;
using AutoMapper;
using Core.Dtos;
using Core.Dtos.CreateDto;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AppointmentController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppointmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<AppointmentDto>>> GetAppointments(
            [FromQuery] AppointmentSpecParams appointmentParams
        )
        {
            var spec = new AppointmentSpecification(appointmentParams);
            var countSpec = new AppointmentFilterForCountSpecification(appointmentParams);
            var totalItems = await _unitOfWork.Repository<Appointment>().CountAsync(countSpec);

            var appointments = await _unitOfWork.Repository<Appointment>().ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<AppointmentDto>>(appointments);

            return Ok(new Pagination<AppointmentDto>(appointmentParams.PageIndex, appointmentParams.PageSize, totalItems, data));
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AppointmentDto>> GetAppointment(int id)
        {
            var spec = new AppointmentSpecification(id);
            var appointment = await _unitOfWork.Repository<Appointment>().GetEntityWithSpec(spec);

            if (appointment == null) return NotFound(new ApiResponse(404));

            return Ok(_mapper.Map<AppointmentDto>(appointment));
        }

        // In appointment
        [HttpPost]
        public async Task<ActionResult<Appointment>> CreateAppointment(AppointmentCreateDto appointmentCreateDto)
        {
            var appointment = _mapper.Map<AppointmentCreateDto, Appointment>(appointmentCreateDto);

            _unitOfWork.Repository<Appointment>().Add(appointment);

            var result = await _unitOfWork.Complete();

            if (result <= 0) return BadRequest(new ApiResponse(400, "Problem creating Appointment"));
            return Ok(appointment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Appointment>> UpdatePatient(int id, AppointmentCreateDto appointmentUpdateDto)
        {
            var appointment = await _unitOfWork.Repository<Appointment>().GetByIdAsync(id);
            _mapper.Map(appointmentUpdateDto, appointment);

            var result = await _unitOfWork.Complete();
            if (result <= 0) return BadRequest(new ApiResponse(400, "Problem updating appointment information"));

            return Ok(appointment);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAppointment(int id)
        {
            var appointment = await _unitOfWork.Repository<Appointment>().GetByIdAsync(id);

            _unitOfWork.Repository<Appointment>().Delete(appointment);

            var result = await _unitOfWork.Complete();

            if (result <= 0) return BadRequest(new ApiResponse(400, "Problem deleting appointment information"));

            return Ok();
        }


        // In Patient
        [HttpGet("patient/{patientId}/appointments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<AppointmentDto>>> GetPatientAppointments(int patientId)
        {
            var spec = new AppointmentSpecification(patientId, getByPatientId: true);
            var appointments = await _unitOfWork.Repository<Appointment>().ListAsync(spec);
            var appointmentDtos = _mapper.Map<IReadOnlyList<AppointmentDto>>(appointments);

            return Ok(appointmentDtos);
        }


        [HttpGet("patient/{patientId}/appointments/{appointmentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AppointmentDto>> GetPatientAppointment(int patientId, int appointmentId)
        {
            var appointmentSpec = new AppointmentSpecification(patientId, appointmentId);
            var appointment = await _unitOfWork.Repository<Appointment>().GetEntityWithSpec(appointmentSpec);

            var appointmentDto = _mapper.Map<AppointmentDto>(appointment);
            return Ok(appointmentDto);
        }

        [HttpPost("patient/{patientId}")]
        public async Task<ActionResult<AppointmentDto>> CreatePatientAppointment(int patientId, AppointmentCreateDto appointmentCreateDto)
        {
            var appointment = _mapper.Map<AppointmentCreateDto, Appointment>(appointmentCreateDto);
            appointment.PatientId = patientId;

            _unitOfWork.Repository<Appointment>().Add(appointment);
            await _unitOfWork.Complete();

            var appointmentDto = _mapper.Map<AppointmentDto>(appointment);
            return Ok(appointmentDto);
        }

        [HttpPut("patient/{patientId}/appointments/{appointmentId}")]
        public async Task<ActionResult<AppointmentDto>> UpdatePatientAppointment(int patientId, int appointmentId, [FromBody] AppointmentCreateDto appointmentToUpdateDto)
        {
            var appointmentSpec = new AppointmentSpecification(patientId, appointmentId);
            var appointment = await _unitOfWork.Repository<Appointment>().GetEntityWithSpec(appointmentSpec);

            if (appointment == null)
            {
                return NotFound(new ApiResponse(404, "Appointment not found"));
            }

            _mapper.Map(appointmentToUpdateDto, appointment);
            _unitOfWork.Repository<Appointment>().Update(appointment);
            await _unitOfWork.Complete();

            var appointmentDto = _mapper.Map<AppointmentDto>(appointment);
            return Ok(appointmentDto);
        }

        [HttpDelete("patient/{patientId}/appointments/{appointmentId}")]
        public async Task<ActionResult> DeletePatientAppointment(int patientId, int appointmentId)
        {
            var appointmentSpec = new AppointmentSpecification(patientId, appointmentId);
            var appointment = await _unitOfWork.Repository<Appointment>().GetEntityWithSpec(appointmentSpec);

            if (appointment == null)
            {
                return NotFound(new ApiResponse(404, "Appointment not found"));
            }

            _unitOfWork.Repository<Appointment>().Delete(appointment);
            await _unitOfWork.Complete();
            return Ok();
        }
    }
}

