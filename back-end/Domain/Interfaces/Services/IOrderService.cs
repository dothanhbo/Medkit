using Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IOrderService
    {
        Task<OrderDto> GetOrderByIdAsync(Guid id);
        Task<List<OrderDto>> GetOrders(int pageIndex, int pageSize);
        Task<OrderDto> CreateOrderAsync(OrderDto orderDto);
    }
}
