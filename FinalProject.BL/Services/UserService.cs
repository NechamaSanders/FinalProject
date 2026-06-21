using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.BL.DTOs;
using FinalProject.DAL.Entities;
using FinalProject.DAL.Repositories;

namespace FinalProject.BL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Specialty = u.Specialty
            });
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Specialty = user.Specialty
            };
        }

        public async Task<UserDto> CreateUserAsync(UserCreateDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Specialty = dto.Specialty
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Specialty = user.Specialty
            };
        }
        public async Task<bool> UpdateUserAsync(int id, UserCreateDto dto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return false;
            user.Name = dto.Name;
            user.Specialty = dto.Specialty;
            _userRepository.Update(user);
            return await _userRepository.SaveChangesAsync();
        }
        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return false;

            _userRepository.Delete(user);
            return await _userRepository.SaveChangesAsync();
        }
    }
}
