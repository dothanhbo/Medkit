using Application.Services;
using Domain.Interfaces.Services;
using Domain.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace medkit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsingHistoryController : ControllerBase
    {
        private readonly IUsingHistoryService usingHistoryService;
        private readonly IMedicineService medicineService;

        public UsingHistoryController(IUsingHistoryService usingHistoryService, IMedicineService medicineService)
        {
            this.usingHistoryService = usingHistoryService;
            this.medicineService = medicineService;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsingHistoryAsync(Guid id)
        {
            var result = await usingHistoryService.GetUsingHistoryAsync(id);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> AddUsingHistory(Guid id, string medicineName, UsingHistoryDto usingHistoryDto)
        {
            var medicine = await medicineService.GetMedicinesByName(id, medicineName);
            var result = await usingHistoryService.AddUsingHistoryAsync(medicine, usingHistoryDto);
            return Ok(result);
        }
    }
}
