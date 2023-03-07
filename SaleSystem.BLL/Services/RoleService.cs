using AutoMapper;
using SaleSystem.BLL.Interfaces;
using SaleSystem.DAL.Interfaces;
using SaleSystem.DTO.Dtos;
using SaleSystem.Entities.Entities;

namespace SaleSystem.BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Role> _genericRepository;
        public RoleService(IMapper mapper, IGenericRepository<Role> roleRepository)
        {
            _mapper = mapper;
            _genericRepository = roleRepository;
        }

        public async Task<List<RoleDto>> List()
        {
            try
            {
                var query = await _genericRepository.MakeQuery();
                return _mapper.Map<List<RoleDto>>(query);
            }
            catch
            {
                throw;
            }
        }
    }
}
