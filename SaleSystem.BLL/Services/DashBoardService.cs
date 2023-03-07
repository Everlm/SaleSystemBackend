using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using SaleSystem.BLL.Interfaces;
using SaleSystem.DAL.Interfaces;
using SaleSystem.DTO.Dtos;
using SaleSystem.Entities.Entities;
using System.Globalization;

namespace SaleSystem.BLL.Services
{
    public class DashBoardService : IDashBoardService
    {
        private readonly IMapper _mapper;
        private readonly ISaleRepository _saleRepository;
        private readonly IGenericRepository<Product> _genericRepository;

        public DashBoardService(IMapper mapper, ISaleRepository saleRepository, IGenericRepository<Product> genericRepository)
        {
            _mapper = mapper;
            _saleRepository = saleRepository;
            _genericRepository = genericRepository;
        }

        private IQueryable<Sale> GetSales(IQueryable<Sale> saleTable, int daysNumber)
        {
            DateTime? lastDate = saleTable.OrderByDescending(s => s.CreationDate).Select(s => s.CreationDate).First();
            lastDate = lastDate.Value.AddDays(daysNumber);
            return saleTable.Where(s => s.CreationDate.Value.Date >= lastDate.Value.Date);
        }

        private async Task<int> TotalSalesLastWeek()
        {
            int total = 0;
            IQueryable<Sale> query = await _saleRepository.MakeQuery();

            if (query.Count() > 0)
            {
                var saleTable = GetSales(query, -7);
                total = saleTable.Count();
            }

            return total;
        }

        private async Task<string> TotalIncomesLastWeek()
        {
            decimal total = 0;
            IQueryable<Sale> query = await _saleRepository.MakeQuery();

            if (query.Count() > 0)
            {
                var saleTable = GetSales(query, -7);
                total = saleTable.Select(s => s.Total).Sum(s => s.Value);
            }

            return Convert.ToString(total, new CultureInfo("es-CO"));

        }

        private async Task<int> TotalProducts()
        {
            IQueryable<Product> query = await _genericRepository.MakeQuery();
            int total = query.Count();
            return total;
        }

        private async Task<Dictionary<string, int>> SalesLastWeek()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            IQueryable<Sale> query = await _saleRepository.MakeQuery();

            if (query.Count() > 0)
            {
                var saleTable = GetSales(query, -7);

                result = saleTable
                    .GroupBy(s => s.CreationDate.Value.Date).OrderBy(g => g.Key)
                    .Select(sd => new { date = sd.Key.ToString("dd/MM/yyyy"), total = sd.Count() })
                    .ToDictionary(keySelector: r => r.date, elementSelector: s => s.total);
            }

            return result;
        }
        public async Task<DashBoardDto> GetDashBoard()
        {
            DashBoardDto dashBoardDto = new DashBoardDto();

            try
            {
                dashBoardDto.TotalSale = await TotalSalesLastWeek();
                dashBoardDto.TotalIncome = await TotalIncomesLastWeek();
                dashBoardDto.TotalProducts = await TotalProducts();

                List<WeekSaleDto> listLastWeek = new List<WeekSaleDto>();

                foreach (KeyValuePair<string, int> item in await SalesLastWeek())
                {
                    listLastWeek.Add(new WeekSaleDto()
                    {
                        Date = item.Key,
                        Total = item.Value,
                    });
                }

                dashBoardDto.WeekSale = listLastWeek;
            }
            catch
            {
                throw;
            }

            return dashBoardDto;
        }
    }
}
