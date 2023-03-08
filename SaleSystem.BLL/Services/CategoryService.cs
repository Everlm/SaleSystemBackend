using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaleSystem.BLL.Interfaces;
using SaleSystem.DAL.Interfaces;
using SaleSystem.DTO.Dtos;
using SaleSystem.Entities.Entities;

namespace SaleSystem.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _genericRepository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Category> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> List()
        {
            try
            {
                var query = await _genericRepository.MakeQuery();
                return _mapper.Map<List<CategoryDto>>(query.ToList());
            }
            catch
            {
                throw;
            }
        }
    }
}
