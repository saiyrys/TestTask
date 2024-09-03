using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using TestTask.ApplicationCore.Interface.IServices;
using TestTask.ApplicationCore.Models;
using TestTask.ApplicationCore.Services;

namespace TestTask.Web.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class doctorsController : Controller
    {
        private readonly IDoctorService _doctorService;

        public doctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet] 
        public async Task<IActionResult> GetDoctors(int page, string? sort = null, string? type = null)
        {
            var (doctors, totalPages) = await _doctorService.GetAllDoctors(page, sort, type);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(new { Items = doctors, TotalPages = totalPages });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetDoctorById(string id)
        {
            var doctor = await _doctorService.GetDoctorsByID(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(doctor);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDoctors(CreateDoctorsDto createDoctors)
        {
            await _doctorService.AddDoctorsData(createDoctors);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(true);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateDoctorData(string id, UpdateDoctorsDto updateDoctors)
        {
            await _doctorService.UpdateDoctorsData(id, updateDoctors);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(true);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(string id)
        {
            var result = await _doctorService.DeleteDoctors(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(true);
        }
       
    }
}
