using Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<ProductDto> GetProductByIdAsync(Guid id);
        Task<ProductDto> GetProductByCodeAsync(string code);
    }
}
