using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BloodTestController : Controller
    {
        private readonly IBloodTestRepository _repo;

        public BloodTestController(IBloodTestRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BloodTest>>> GetBloodTests(){
            var bloodTest = await _repo.GetBloodTestsAsync();
            return Ok(bloodTest);
        }
    }
}