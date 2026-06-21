using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.BL.DTOs;

namespace FinalProject.BL.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task<UserDto> CreateUserAsync(UserCreateDto userDto);
        Task<bool> UpdateUserAsync(int id, UserCreateDto userDto);
        Task<bool> DeleteUserAsync(int id);
    }
}
