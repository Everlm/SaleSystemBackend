using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaleSystem.BLL.Interfaces;
using SaleSystem.DAL.Interfaces;
using SaleSystem.DTO.Dtos;
using SaleSystem.Entities.Entities;

namespace SaleSystem.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<User> _genericRepository;

        public UserService(IMapper mapper, IGenericRepository<User> genericRepository)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
        }

        public async Task<List<UserDto>> List()
        {
            try
            {
                var query = await _genericRepository.MakeQuery();
                var userList = query.Include(r => r.Role).ToList();
                return _mapper.Map<List<UserDto>>(userList);
            }
            catch
            {
                throw;
            }
        }
        public async Task<SessionDto> ValidateCredentials(string email, string password)
        {
            try
            {
                var query = await _genericRepository.MakeQuery(u => u.Email == email && u.Password == password);

                if (query.FirstOrDefault() == null)
                    throw new TaskCanceledException("user does not exist");

                User user = query.Include(r => r.Role).First();
                return _mapper.Map<SessionDto>(user);

            }
            catch
            {
                throw;
            }
        }
        public async Task<UserDto> Create(UserDto user)
        {
            try
            {
                var createUser = await _genericRepository.Create(
                    _mapper.Map<User>(user));

                if (createUser.UserId == 0)
                    throw new TaskCanceledException("Error");

                var query = await _genericRepository.MakeQuery(u => u.UserId == createUser.UserId);
                createUser = query.Include(r => r.Role).First();
                return _mapper.Map<UserDto>(createUser);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Edit(UserDto user)
        {
            try
            {
                var userMap = _mapper.Map<User>(user);
                var findUser = await _genericRepository.GetBy(u => u.UserId == userMap.UserId);
                if (findUser == null)
                    throw new TaskCanceledException("Error");

                findUser.FullName = userMap.FullName;
                findUser.Email = userMap.Email;
                findUser.RoleId = userMap.RoleId;
                findUser.Password = userMap.Password;
                findUser.IsActive = userMap.IsActive;

                bool response = await _genericRepository.Edit(findUser);
                if (!response)
                    throw new TaskCanceledException("Error");

                return response;

            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var query = await _genericRepository.GetBy(u => u.UserId == id);
                if (query == null)
                    throw new TaskCanceledException("Error");

                bool response = await _genericRepository.Delete(query);
                if (!response)
                    throw new TaskCanceledException("Error");

                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}
