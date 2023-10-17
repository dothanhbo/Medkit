using Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IUsingHistoryService
    {
        Task<UsingHistoryDto> AddUsingHistoryAsync(MedicineDto medicineDto, UsingHistoryDto usingHistoryDto);
        Task<List<UsingHistoryDto>> GetUsingHistoryAsync(Guid id);
    }
}
