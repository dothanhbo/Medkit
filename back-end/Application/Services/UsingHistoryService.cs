using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UsingHistoryService : IUsingHistoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public UsingHistoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<UsingHistoryDto> AddUsingHistoryAsync(MedicineDto medicineDto, UsingHistoryDto usingHistoryDto)
        {
            try
            {
                usingHistoryDto.MedicineId = medicineDto.Id;
                var entityToAdd = await unitOfWork.UsingHistory.AddAsync(mapper.Map<UsingHistory>(usingHistoryDto));

                return await unitOfWork.SaveChangesAsync() != 0 ? mapper.Map<UsingHistoryDto>(entityToAdd) : throw new AppException("Added Failed");
            }
            catch (Exception)
            {
                throw new AppException("Error occurred");
            }
        }

        public async Task<List<UsingHistoryDto>?> GetUsingHistoryAsync(Guid id)
        {
            var result = await unitOfWork.UsingHistory.GetUsingHistoryAsync(id);
            if (result.Count == 0)
                return null;
            var dto = mapper.Map<List<UsingHistoryDto>>(result);
            foreach (UsingHistoryDto usingHistoryDto in dto)
            {
                var medicine = await unitOfWork.Medicines.GetAsync(expression: x => x.Id == usingHistoryDto.MedicineId, pageSize: 1);
                usingHistoryDto.MedicineName = medicine.Result[0].Name;
            }
            return dto;
        }
    }
}
