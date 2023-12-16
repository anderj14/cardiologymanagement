
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
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
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

            return Ok(new Pagination<AppointmentDto>(appointmentParams.PageIndex,
            appointmentParams.PageSize, totalItems, data));
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

        [HttpGet("patient/{patientId}/appointments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<AppointmentDto>>> GetPatientAppointments(int patientId)
        {
            var spec = new AppointmentSpecification(patientId);
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
    }
}

