
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
    public class AppointmentController : ControllerBase
    {
        private readonly IGenericRepository<Appointment> _appointmentRepo;

        private readonly IMapper _mapper;

        public AppointmentController(IGenericRepository<Appointment> appointmentRepo,
        IMapper mapper)
        {
            _appointmentRepo = appointmentRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppointmentDto>>> GetAppointments()
        {
            var appointments = await _appointmentRepo.ListAllAsync();
            var appointmentDtos = _mapper.Map<IReadOnlyList<AppointmentDto>>(appointments);

            return Ok(appointmentDtos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AppointmentDto>> GetAppointment(int id)
        {
            var appointment = await _appointmentRepo.GetByIdAsync(id);
            var appointmentDto = _mapper.Map<AppointmentDto>(appointment);

            return Ok(appointmentDto);
        }

        [HttpGet("patient/{patientId}/appointments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<AppointmentDto>>> GetPatientAppointments(int patientId)
        {
            var spec = new AppointmentSpecification(patientId);
            var appointments = await _appointmentRepo.ListAsync(spec);
            var appointmentDtos = _mapper.Map<IReadOnlyList<AppointmentDto>>(appointments);

            return Ok(appointmentDtos);
        }

        [HttpGet("patient/{patientId}/appointments/{appointmentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AppointmentDto>> GetPatientAppointment(int patientId, int appointmentId)
        {
            var appointmentSpec = new AppointmentSpecification(patientId, appointmentId);
            var appointment = await _appointmentRepo.GetEntityWithSpec(appointmentSpec);
 
            var appointmentDto = _mapper.Map<AppointmentDto>(appointment);
            return Ok(appointmentDto);
        }
    }
}