using Domain.Entities;
using Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDto> LoginAsync(LoginModel loginModel);
        Task<List<UserDto>> GetUsersByProductIdAsync(Guid id);
        Task<Guid> CheckUsersByProductCodeAsync(string code);
        Task<UserDto> AddUser(UserDto userDto);
        Task<UserDto> CheckEmail(String email);
        Task ChangePassword(Guid id, string password);
        Task<List<UserDto>> GetUsers(int pageIndex, int pageSize);
    }
}
