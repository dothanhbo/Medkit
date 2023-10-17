using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Exceptions;
using Domain.Entities;

namespace Application.Services
{
    public class OriginalMedicineService : IOriginalMedicineService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public OriginalMedicineService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<OriginalMedicineDto> GetOriginalMedicineByIdAsync(Guid id)
        {
            var result = await unitOfWork.OriginalMedicines.GetAsync(expression: o => o.Id.Equals(id), pageSize: 1);
            if (result.Result.Count == 0)
                throw new KeyNotFoundException($"Cannot found Id: {id}");
            return mapper.Map<OriginalMedicineDto>(result.Result[0]);
        }
        public async Task<List<OriginalMedicineDto>> GetAllOriginalMedicines()
        {
            var result = await unitOfWork.OriginalMedicines.GetAsync(isTakeAll: true);
            if (result.Result.Count == 0)
                throw new KeyNotFoundException($"Cannot found");
            return mapper.Map<List<OriginalMedicineDto>>(result.Result);
        }
        public async Task<OriginalMedicineDto> AddOriginalMedicineAsync(OriginalMedicineDto originalMedicine)
        {
            var medicine = await unitOfWork.OriginalMedicines.GetAsync(expression: o => o.Id == originalMedicine.Id, pageSize: 1);
            if (medicine.TotalCount != 0)
            {
                throw new Exception("There is an medicine with the id " + originalMedicine.Id);
            }  
            try
            {
                var entityToAdd = await unitOfWork.OriginalMedicines.AddAsync(mapper.Map<OriginalMedicine>(originalMedicine));
                return unitOfWork.SaveChanges() != 0 ? mapper.Map<OriginalMedicineDto>(entityToAdd): throw new AppException("Added Failed");
            }
            catch (Exception)
            {
                throw new AppException("Error occurred");
            }
        }
        public async Task<bool> DeleteOriginalMedicineAsync(Guid id)
        {
            var medicine = await unitOfWork.OriginalMedicines.GetAsync(expression: o => o.Id == id, pageSize: 1);
            try
            {
                await unitOfWork.OriginalMedicines.DeleteAsync(medicine.Result[0].Id);
                return unitOfWork.SaveChanges() > 0 ? true : throw new AppException("Added Failed");
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }   
}
