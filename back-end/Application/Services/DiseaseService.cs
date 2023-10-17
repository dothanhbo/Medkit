using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DiseaseService : IDiseaseService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public DiseaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<DiseaseDto> GetDiseaseByIdAsync(Guid id)
        {
            var result = await unitOfWork.Diseases.GetAsync(expression: o => o.Id.Equals(id), pageSize: 1);
            if (result.Result.Count == 0)
                throw new KeyNotFoundException($"Cannot found Id: {id}");
            result.Result[0].MedicineDisease = await unitOfWork.MedicineDisease.GetMedicinesByDiseaseId(id);
            foreach(MedicineDisease medicineDisease in result.Result[0].MedicineDisease)
            {
                var OriginalMedicines = await unitOfWork.OriginalMedicines.GetAsync(expression: o => o.Id.Equals(medicineDisease.OriginalMedicineId), pageSize: 1);
                medicineDisease.OriginalMedicine = OriginalMedicines.Result[0];
            }
            return mapper.Map<DiseaseDto>(result.Result[0]);
        }
        public async Task<List<DiseaseDto>> GetAllDiseasesAsync()
        {
            var result = await unitOfWork.Diseases.GetAsync(isTakeAll: true);
            if (result.Result.Count == 0)
                throw new KeyNotFoundException($"Cannot found");
            List<DiseaseDto> diseaseDtos = mapper.Map<List<DiseaseDto>>(result.Result);
            foreach (DiseaseDto dto in diseaseDtos) 
            {
                List<MedicineDisease> medicineDiseases = await unitOfWork.MedicineDisease.GetMedicinesByDiseaseId(dto.Id.Value);
                List<OriginalMedicineDto> originalMedicineDtos = new List<OriginalMedicineDto>();
                foreach (MedicineDisease medicineDisease in medicineDiseases) 
                {
                    var medicine = await unitOfWork.OriginalMedicines.GetAsync(expression: o => o.Id.Equals(medicineDisease.OriginalMedicineId), pageSize: 1);
                    originalMedicineDtos.Add(mapper.Map<OriginalMedicineDto>(medicine.Result[0]));
                }
                dto.OriginalMedicines = originalMedicineDtos;
            }
            return diseaseDtos;
        }
    }
}
