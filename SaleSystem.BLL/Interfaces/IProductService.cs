using SaleSystem.DTO.Dtos;

namespace SaleSystem.BLL.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> List();
        Task<ProductDto> Create(ProductDto product );
        Task<bool> Edit(ProductDto product);
        Task<bool> Delete(int id);
    }
}
