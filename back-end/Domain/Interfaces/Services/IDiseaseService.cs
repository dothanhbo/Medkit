using Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IDiseaseService
    {
        Task<DiseaseDto> GetDiseaseByIdAsync(Guid id);
        Task<List<DiseaseDto>> GetAllDiseasesAsync();
    }
}
