using SaleSystem.Entities.Entities;

namespace SaleSystem.DAL.Interfaces
{
    public interface ISaleRepository :IGenericRepository<Sale>
    {
        Task<Sale> Register(Sale sale);

    }
}
