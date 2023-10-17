using Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IOriginalMedicineService
    {
        Task<OriginalMedicineDto> GetOriginalMedicineByIdAsync(Guid id);
        Task<List<OriginalMedicineDto>> GetAllOriginalMedicines();
        Task<OriginalMedicineDto> AddOriginalMedicineAsync(OriginalMedicineDto originalMedicine);
        Task<bool> DeleteOriginalMedicineAsync(Guid id);
    }
}
