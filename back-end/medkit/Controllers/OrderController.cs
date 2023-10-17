using Application.Services;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace medkit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var result = await orderService.GetOrderByIdAsync(id);
            return Ok(result);
        }
        [HttpGet("pagination")]
        public async Task<IActionResult> GetOrders(int pageIndex, int pageSize)
        {
            var result = await orderService.GetOrders(pageIndex, pageSize);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync(OrderDto orderDto)
        {
            var result = await orderService.CreateOrderAsync(orderDto);
            return Ok(result);
        }
    }
}
