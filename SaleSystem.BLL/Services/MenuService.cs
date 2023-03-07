using AutoMapper;
using SaleSystem.BLL.Interfaces;
using SaleSystem.DAL.Interfaces;
using SaleSystem.DTO.Dtos;
using SaleSystem.Entities.Entities;

namespace SaleSystem.BLL.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<User> _userGenericRepository;
        private readonly IGenericRepository<MenuRole> _menuRoleGenericRepository;
        private readonly IGenericRepository<Menu> _menuGenericRepository;

        public MenuService(IMapper mapper, IGenericRepository<User> userGenericRepository, IGenericRepository<MenuRole> menuRoleGenericRepository,
                           IGenericRepository<Menu> menuGenericRepository)
        {
            _mapper = mapper;
            _userGenericRepository = userGenericRepository;
            _menuRoleGenericRepository = menuRoleGenericRepository;
            _menuGenericRepository = menuGenericRepository;
        }

        public async Task<List<MenuDto>> List(int userId)
        {
            IQueryable<User> user = await _userGenericRepository.MakeQuery(u => u.UserId == userId);
            IQueryable<MenuRole> menuRole = await _menuRoleGenericRepository.MakeQuery();
            IQueryable<Menu> menu = await _menuGenericRepository.MakeQuery();

            try
            {
                IQueryable<Menu> result = (from u in user
                                           join mr in menuRole on u.RoleId equals mr.RoleId
                                           join m in menu on mr.MenuId equals m.MenuId
                                           select m).AsQueryable();

                var menuList = result.ToList();
                return _mapper.Map<List<MenuDto>>(menuList);

            }
            catch
            {
                throw;
            }
        }
    }
}
