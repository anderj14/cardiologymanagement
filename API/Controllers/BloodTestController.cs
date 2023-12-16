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
    public class BloodTestController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BloodTestController(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BloodTestDto>>> GetBloodTests()
        {
            var bloodTests = await _unitOfWork.Repository<BloodTest>().ListAllAsync();
            var bloodTestsDtos = _mapper.Map<IReadOnlyList<BloodTestDto>>(bloodTests);

            return Ok(bloodTestsDtos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BloodTestDto>> GetBloodTest(int id)
        {
            var bloodTest = await _unitOfWork.Repository<BloodTest>().GetByIdAsync(id);
            var bloodTestDtos = _mapper.Map<BloodTestDto>(bloodTest);

            return Ok(bloodTestDtos);
        }

        [HttpGet("patient/{patientId}/bloodTests")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<BloodTestDto>>> GetPatientBloodTest(int patientId)
        {
            var spec = new BloodTestSpecification(patientId);
            var bloodTests = await _unitOfWork.Repository<BloodTest>().ListAsync(spec);
            var bloodTestsDtos = _mapper.Map<IReadOnlyList<BloodTestDto>>(bloodTests);

            return Ok(bloodTestsDtos);
        }

        [HttpGet("patient/{patientId}/bloodTests/{bloodTestId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BloodTestDto>> GetPatientBloodTest(int patientId, int bloodTestId)
        {

            var spec = new BloodTestSpecification(patientId, bloodTestId);
            var bloodTest = await _unitOfWork.Repository<BloodTest>().GetEntityWithSpec(spec);

            var bloodTestDto = _mapper.Map<BloodTestDto>(bloodTest);
            return Ok(bloodTestDto);
        }
    }
}