using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace medkit.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : Controller
    {
        private readonly IMedicineService medicineService;

        public MedicineController(IMedicineService medicineService)
        {
            this.medicineService = medicineService;
        }
        [HttpGet]
        public async Task<IActionResult> GetFamilyMedicines(Guid id)
        {
            var result = await medicineService.GetFamilyMedicines(id);
            return Ok(result);
        }
        [HttpGet("{name}")]
        public async Task<IActionResult> GetMedicinesByName(Guid id, string name)
        {
            var result = await medicineService.GetMedicinesByName(id, name);
            return Ok(result);
        }
    }
}
