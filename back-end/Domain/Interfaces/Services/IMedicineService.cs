using Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IMedicineService
    {
        Task<List<MedicineDto>> GetFamilyMedicines(Guid id);
        Task<MedicineDto> GetMedicinesByName(Guid id, string name);
    }
}
