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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<ProductDto> GetProductByIdAsync(Guid id)
        {
            var result = await unitOfWork.Products.GetAsync(expression: o => o.Id.Equals(id), pageSize: 1);
            if (result.Result.Count == 0)
                throw new KeyNotFoundException($"Cannot found Id: {id}");
            return mapper.Map<ProductDto>(result.Result[0]);
        }
        public async Task<ProductDto> GetProductByCodeAsync(string code)
        {
            var result = await unitOfWork.Products.GetAsync(expression: o => o.code.Equals(code), pageSize: 1);
            if (result.Result.Count == 0)
                throw new KeyNotFoundException($"Cannot found Code: {code}");
            var dto = mapper.Map<ProductDto>(result.Result[0]);
            var user = await unitOfWork.Users.GetAsync(expression: o => o.ProductId == dto.Id, isTakeAll: true);
            dto.User = mapper.Map<List<UserDto>>(user.Result);
            return dto;

        }
    }
}
