using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using Domain.Models.DTOs;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Exceptions;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<OrderDto> GetOrderByIdAsync(Guid id)
        {
            var result = await unitOfWork.Orders.GetAsync(expression: o => o.Id.Equals(id), pageSize: 1);
            if (result.Result.Count == 0)
                throw new KeyNotFoundException($"Cannot found Id: {id}");
            return mapper.Map<OrderDto>(result.Result[0]);
        }
        public async Task<OrderDto> CreateOrderAsync(OrderDto orderDto)
        {
            try
            {
                var entityToAdd = await unitOfWork.Orders.AddAsync(mapper.Map<Order>(orderDto));
                return unitOfWork.SaveChanges() != 0 ? mapper.Map<OrderDto>(entityToAdd) : throw new AppException("Added Failed");
            }
            catch (Exception)
            {
                throw new AppException("Error occurred");
            }
        }
        public async Task<List<OrderDto>> GetOrders(int pageIndex, int pageSize)
        {
            var result = await unitOfWork.Orders.GetAsync(pageIndex: pageIndex, pageSize: pageSize);
            if (result.Result.Count == 0)
                throw new KeyNotFoundException($"Cannot found");
            return mapper.Map<List<OrderDto>>(result.Result);
        }
    }
}
