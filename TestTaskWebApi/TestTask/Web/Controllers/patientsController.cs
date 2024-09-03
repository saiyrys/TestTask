using Microsoft.AspNetCore.Mvc;
using TestTask.Anexs.Dto.PatientsDtos;
using TestTask.ApplicationCore.Interface.IRepositories;
using TestTask.ApplicationCore.Interface.IServices;

namespace TestTask.Web.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class patientsController : Controller
    {
        private readonly IPatientsRepository _patientsRepository;
        private readonly IPatientsService _patientsService;
        public patientsController(IPatientsRepository patientsRepository, IPatientsService patientsService)
        {
            _patientsRepository = patientsRepository;
            _patientsService = patientsService;
        }

        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetAllPatients(int page, string? sort = null, string? type = null)
        {
            var (patients, totalPages) = await _patientsService.GetPatients(page, sort, type);

            return Ok(new { Items = patients, TotalPages = totalPages }); 
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetPatientsById(string id)
        {
            var patients = await _patientsService.GetPatientsByID(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(patients);
        }

        [HttpPost]
        public async Task<IActionResult> AddPatients(CreatePatientsDto patients)
        {
            await _patientsService.AddPatients(patients);

            return Ok(true);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePatientsData(string id, UpdatePatientsDto patients)
        {
            var patientsUpdate = await _patientsService.UpdatePatients(id, patients);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(true);
        }
         
        [HttpDelete]
        public async Task<IActionResult> DeletePatients(string patientsId)
        {
            var result = await _patientsService.DeletePatients(patientsId);

            return Ok(true);
        }

    }
}
