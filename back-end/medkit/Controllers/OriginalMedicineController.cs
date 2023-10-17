using Domain.Interfaces.Services;
using Domain.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace medkit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OriginalMedicineController : ControllerBase
    {
        private readonly IOriginalMedicineService originalMedicineService;

        public OriginalMedicineController(IOriginalMedicineService originalMedicineService)
        {
            this.originalMedicineService = originalMedicineService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOriginalMedicineById(Guid id)
        {
            var result = await originalMedicineService.GetOriginalMedicineByIdAsync(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOriginalMedicines()
        {
            var result = await originalMedicineService.GetAllOriginalMedicines();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddOriginalMedicineAsync(OriginalMedicineDto originalMedicineDto)
        {
            var result = await originalMedicineService.AddOriginalMedicineAsync(originalMedicineDto);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOriginalMedicine(Guid id)
        {
            var result = await originalMedicineService.DeleteOriginalMedicineAsync(id);
            if (result == true)
                return Ok(new ApiResponse
                {
                    Success = true,
                    Message = "Delete success!"
                });
            else
                return BadRequest();
        }
    }
}
