using SaleSystem.DAL.Context;
using SaleSystem.DAL.Interfaces;
using SaleSystem.Entities;

namespace SaleSystem.DAL.Repositories
{
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {

        private readonly DBSALEContext _context;

        public SaleRepository(DBSALEContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Sale> Register(Sale sale)
        {
            Sale GeneratedSale = new Sale();

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    //Update SaleDetails
                    foreach (SaleDetail item in sale.SaleDetails)
                    {
                        Product product = _context.Products.Where(p => p.ProductId == item.ProductId).First();

                        product.Stock = product.Stock - item.Quantity;
                        _context.Products.Update(product);
                    }

                    await _context.SaveChangesAsync();

                    //Generate consecutive
                    DocumentNumber number = _context.DocumentNumbers.First();
                    number.LastNumber = number.LastNumber + 1;
                    number.CreationDate = DateTime.Now;

                    _context.DocumentNumbers.Update(number);
                    await _context.SaveChangesAsync();

                    int lengthNumer = 4;
                    string zero = string.Concat(Enumerable.Repeat("0", lengthNumer));
                    string saleNumber = zero + number.LastNumber.ToString();
                    saleNumber = saleNumber.Substring(saleNumber.Length - lengthNumer, lengthNumer);

                    sale.DocumentNumeber = saleNumber;
                    //End Generate consecutive

                    await _context.Sales.AddAsync(sale);
                    await _context.SaveChangesAsync();

                    GeneratedSale = sale;
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }

                return GeneratedSale;
            }
        }
    }
}
