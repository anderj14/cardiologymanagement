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
    public class BloodTestController : ControllerBase
    {
        private readonly IGenericRepository<BloodTest> _bloodTestRepo;
        private readonly IGenericRepository<Patient> _patientRepo;

        private readonly IMapper _mapper;

        public BloodTestController(
            IGenericRepository<BloodTest> bloodTestRepo,
            IGenericRepository<Patient> patientRepo,
            IMapper mapper)
        {
            _bloodTestRepo = bloodTestRepo;
            _patientRepo = patientRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BloodTestDto>>> GetBloodTests()
        {
            var bloodTests = await _bloodTestRepo.ListAllAsync();
            var bloodTestsDtos = _mapper.Map<IReadOnlyList<BloodTestDto>>(bloodTests);

            return Ok(bloodTestsDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BloodTestDto>> GetBloodTest(int id)
        {
            var bloodTest = await _bloodTestRepo.GetByIdAsync(id);
            var bloodTestDtos = _mapper.Map<BloodTestDto>(bloodTest);

            return Ok(bloodTestDtos);
        }

        [HttpGet("patient/{patientId}/BloodTests")]
        public async Task<ActionResult<IReadOnlyList<BloodTestDto>>> GetPatientBloodTest(int patientId)
        {
            var spec = new BloodTestSpecification(patientId);
            var bloodTests = await _bloodTestRepo.ListAsync(spec);
            var bloodTestsDtos = _mapper.Map<IReadOnlyList<BloodTestDto>>(bloodTests);

            return Ok(bloodTestsDtos);
        }

        [HttpGet("{patientId}/appointment/{appointmentId}")]
        public async Task<ActionResult<BloodTestDto>> GetPatientBloodTest(int patientId, int bloodTestId)
        {
            var patient = await _patientRepo.GetByIdAsync(patientId);
            if (patient == null)
            {
                return NotFound("Patient not found");
            }

            var spec = new BloodTestSpecification(patientId, bloodTestId);
            var bloodTest = await _bloodTestRepo.GetEntityWithSpec(spec);
            if (bloodTest == null)
            {
                return NotFound("Blood test not found");
            }

            var bloodTestDto = _mapper.Map<BloodTestDto>(bloodTest);
            return Ok(bloodTestDto);
        }
    }
}