using AutoMapper;
using Domain.Interfaces.Services;
using Domain.Interfaces;
using Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Exceptions;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<UserDto> LoginAsync(LoginModel loginModel)
        {
            var result = await unitOfWork.Users.GetAsync(expression: o => o.Email.ToLower().Equals(loginModel.Email) && o.Password.Equals(loginModel.Password), pageSize: 1);
            if (result.Result.Count == 0)
                throw new KeyNotFoundException($"Wrong email or password!");
            return mapper.Map<UserDto>(result.Result[0]);
        }
        public async Task<List<UserDto>> GetUsersByProductIdAsync(Guid id)
        {
            var result = await unitOfWork.Users.GetAsync(expression: o => o.ProductId == id, isTakeAll: true);
            if (result.Result.Count == 0)
                throw new KeyNotFoundException($"Wrong email or password!");
            return mapper.Map<List<UserDto>>(result.Result);
        }
        public async Task<Guid> CheckUsersByProductCodeAsync(string code)
        {
            var product = await unitOfWork.Products.GetAsync(expression: o => o.code == code, pageSize: 1);
            if (product.Result.Count == 0)
                throw new KeyNotFoundException($"Product code is invalid");
            return product.Result[0].Id;
        }
        public async Task<UserDto> AddUser(UserDto userDto)
        {
            try
            {
                var entityToAdd = await unitOfWork.Users.AddAsync(mapper.Map<User>(userDto));
                return unitOfWork.SaveChanges() != 0 ? mapper.Map<UserDto>(entityToAdd) : throw new AppException("Added Failed");
            }
            catch (Exception)
            {
                throw new AppException("Error occurred");
            }
        }
        public async Task<UserDto> CheckEmail(String email)
        {
            var user = await unitOfWork.Users.GetAsync(expression: o => o.Email.ToLower().Equals(email.ToLower()), pageSize: 1);
            if (user.Result.Count == 0)
                throw new KeyNotFoundException($"Email not found");
            return mapper.Map<UserDto>(user.Result[0]);
        }
        public async Task ChangePassword(Guid id, string password)
        {
            var user = await unitOfWork.Users.GetAsync(expression: o => o.Id == id, pageSize: 1);
            user.Result[0].Password = password;
            unitOfWork.Users.UpdateAsync(user.Result[0]);
            var result = await unitOfWork.SaveChangesAsync();
            if (result <= 0)
                throw new KeyNotFoundException($"Can not change");
        }
        public async Task<List<UserDto>> GetUsers(int pageIndex, int pageSize)
        {
            var result = await unitOfWork.Users.GetAsync(pageIndex: pageIndex, pageSize: pageSize);
            if (result.Result.Count == 0)
                throw new KeyNotFoundException($"Cannot found");
            return mapper.Map<List<UserDto>>(result.Result);
        }
    }
}
