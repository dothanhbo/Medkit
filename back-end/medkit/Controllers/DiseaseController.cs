using Application.Services;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace medkit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseaseController : ControllerBase
    {
        private readonly IDiseaseService diseaseService;

        public DiseaseController(IDiseaseService diseaseService)
        {
            this.diseaseService = diseaseService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiseaseById(Guid id)
        {
            var result = await diseaseService.GetDiseaseByIdAsync(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDiseases()
        {
            var result = await diseaseService.GetAllDiseasesAsync();
            return Ok(result);
        }
    }
}
