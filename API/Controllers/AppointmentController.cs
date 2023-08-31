
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IGenericRepository<Appointment> _appointmentRepo;
        private readonly IGenericRepository<Patient> _patientRepo;

        private readonly IMapper _mapper;

        public AppointmentController(IGenericRepository<Appointment> appointmentRepo,
         IGenericRepository<Patient> patientRepo, IMapper mapper)
        {
            _appointmentRepo = appointmentRepo;
            _patientRepo = patientRepo;
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
        public async Task<ActionResult<AppointmentDto>> GetAppointment(int id)
        {
            var appointment = await _appointmentRepo.GetByIdAsync(id);
            var appointmentDto = _mapper.Map<AppointmentDto>(appointment);

            return Ok(appointmentDto);
        }

        [HttpGet("patient/{patientId}/appointments")]
        public async Task<ActionResult<IReadOnlyList<AppointmentDto>>> GetPatientAppointments(int patientId)
        {
            var spec = new AppointmentSpecification(patientId);
            var appointments = await _appointmentRepo.ListAsync(spec);
            var appointmentDtos = _mapper.Map<IReadOnlyList<AppointmentDto>>(appointments);

            return Ok(appointmentDtos);
        }

        [HttpGet("{patientId}/appointments/{appointmentId}")]
        public async Task<ActionResult<AppointmentDto>> GetPatientAppointment(int patientId, int appointmentId)
        {
            var patient = await _patientRepo.GetByIdAsync(patientId);

            if (patient == null)
            {
                return NotFound("Patient not found");
            }

            var appointmentSpec = new AppointmentSpecification(patientId, appointmentId);
            var appointment = await _appointmentRepo.GetEntityWithSpec(appointmentSpec);
            if (appointment == null)
            {
                return NotFound("Appointment not found");
            }
            var appointmentDto = _mapper.Map<AppointmentDto>(appointment);
            return Ok(appointmentDto);
        }
    }
}