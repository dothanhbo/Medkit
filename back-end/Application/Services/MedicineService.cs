using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Services;

namespace Application.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public MedicineService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<List<MedicineDto>> GetFamilyMedicines(Guid id)
        {
            var medicine = await unitOfWork.Medicines.GetAsync(expression: o => o.ProductId == id, isTakeAll: true);
            if (medicine.TotalCount == 0)
            {
                var originalMedicines = await unitOfWork.OriginalMedicines.GetAsync(isTakeAll: true);
                foreach (OriginalMedicine originalMedicine in originalMedicines.Result) 
                {
                    await unitOfWork.Medicines.AddAsync(new Medicine
                    {
                        Id = Guid.NewGuid(),
                        Name = originalMedicine.Name,
                        Numbers = originalMedicine.Numbers,
                        Unit = originalMedicine.Unit,
                        Notes = originalMedicine.Notes,
                        ProductId = id
                    });
                    if (unitOfWork.SaveChanges() == 0) throw new AppException("Added Failed");
                }
            }
            var result = await unitOfWork.Medicines.GetAsync(expression: o => o.ProductId == id, isTakeAll: true);
            return mapper.Map<List<MedicineDto>>(result.Result);
        }

        public async Task<MedicineDto> GetMedicinesByName(Guid id, string name)
        {
            var medicine = await unitOfWork.Medicines.GetAsync(expression: o => o.ProductId == id && o.Name.Equals(name), pageSize: 1);
            if (medicine.TotalCount == 0)
            {
                throw new Exception("Can not found!");
            }
            return mapper.Map<MedicineDto>(medicine.Result[0]);
        }
    }
}
