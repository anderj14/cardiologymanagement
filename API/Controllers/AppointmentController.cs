
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepository _repo;
        private readonly IMapper _mapper;

        public AppointmentController(IAppointmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppointmentDto>>> GetAppointments()
        {
            var appointments = await _repo.GetAppointmentsAsync();
            var appointmentDtos = _mapper.Map<List<AppointmentDto>>(appointments);

            return Ok(appointmentDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDto>> GetAppointment(int id)
        {
            var appointment = await _repo.GetAppointmentByIdAsync(id);
            var appointmentDto = _mapper.Map<AppointmentDto>(appointment);

            return Ok(appointmentDto);
        }
    }
}