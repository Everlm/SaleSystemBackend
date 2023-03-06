using SaleSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleSystem.DAL.Interfaces
{
    public interface ISaleRepository :IGenericRepository<Sale>
    {
        Task<Sale> Register(Sale sale);

    }
}
