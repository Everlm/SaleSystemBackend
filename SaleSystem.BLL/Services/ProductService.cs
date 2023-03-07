using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaleSystem.BLL.Interfaces;
using SaleSystem.DAL.Interfaces;
using SaleSystem.DTO.Dtos;
using SaleSystem.Entities.Entities;

namespace SaleSystem.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Product> _genericRepository;

        public ProductService(IMapper mapper, IGenericRepository<Product> genericRepository)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
        }
        public async Task<List<ProductDto>> List()
        {
            try
            {
                var query = await _genericRepository.MakeQuery();
                var listProduct = query.Include(c => c.Category).ToList();
                return _mapper.Map<List<ProductDto>>(listProduct.ToList());
            }
            catch
            {
                throw;
            }
        }
        public async Task<ProductDto> Create(ProductDto product)
        {
            try
            {
                var CreateProduct = await _genericRepository.Create(_mapper.Map<Product>(product));
                if (CreateProduct.ProductId == 0)
                    throw new TaskCanceledException("CreateError");

                return _mapper.Map<ProductDto>(CreateProduct);
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Edit(ProductDto product)
        {
            try
            {
                var productMap = _mapper.Map<Product>(product);
                var findProduct = await _genericRepository.GetBy(p => p.ProductId == product.ProductId);
                if (findProduct == null)
                    throw new TaskCanceledException("FindError");

                findProduct.Name = productMap.Name;
                findProduct.CategoryId = productMap.CategoryId;
                findProduct.Stock = productMap.Stock;
                findProduct.Price = productMap.Price;
                findProduct.IsActive = productMap.IsActive;

                bool response = await _genericRepository.Edit(findProduct);
                if (!response)
                    throw new TaskCanceledException("EditError");

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
                var findProduct = await _genericRepository.GetBy(p => p.ProductId == id);
                if (findProduct == null)
                    throw new TaskCanceledException("FindError");

                bool response = await _genericRepository.Delete(findProduct);
                if (!response)
                    throw new TaskCanceledException("DeleteError");

                return response;
            }
            catch
            {
                throw;
            }
        }

    }
}
