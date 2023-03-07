using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaleSystem.BLL.Interfaces;
using SaleSystem.DAL.Interfaces;
using SaleSystem.DTO.Dtos;
using SaleSystem.Entities.Entities;
using System.Globalization;

namespace SaleSystem.BLL.Services
{
    public class SaleService : ISaleService
    {
        private readonly IMapper _mapper;
        private readonly ISaleRepository _saleRepository;
        private readonly IGenericRepository<SaleDetail> _genericRepository;

        public SaleService(IMapper mapper, ISaleRepository saleRepository, IGenericRepository<SaleDetail> genericRepository)
        {
            _mapper = mapper;
            _saleRepository = saleRepository;
            _genericRepository = genericRepository;
        }

        public async Task<SaleDto> Register(SaleDto sale)
        {
            try
            {
                var saleRegister = await _saleRepository.Register(_mapper.Map<Sale>(sale));
                if (saleRegister.SaleId == 0)
                    throw new TaskCanceledException("RegisterError");

                return _mapper.Map<SaleDto>(saleRegister);
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<SaleDto>> GetHistory(string findBy, string saleNumber, string startDate, string endDate)
        {
            IQueryable<Sale> query = await _saleRepository.MakeQuery();
            var listSale = new List<Sale>();

            try
            {
                if (findBy == "date")
                {
                    DateTime dateStart = DateTime.ParseExact(startDate, "dd/MM/yyyy", new CultureInfo("es-CO"));
                    DateTime dateEnd = DateTime.ParseExact(endDate, "dd/MM/yyyy", new CultureInfo("es-CO"));

                    listSale = await query.Where(s =>
                    s.CreationDate.Value.Date >= dateStart.Date &&
                    s.CreationDate.Value.Date <= dateEnd.Date)
                    .Include(sd => sd.SaleDetails)
                    .ThenInclude(p => p.Product)
                    .ToListAsync();
                }
                else
                {
                    listSale = await query.Where(s => s.DocumentNumeber == saleNumber)
                    .Include(sd => sd.SaleDetails)
                    .ThenInclude(p => p.Product)
                    .ToListAsync();
                }
            }
            catch
            {
                throw;
            }

            return _mapper.Map<List<SaleDto>>(listSale);
        }

        public async Task<List<ReportDto>> Report(string startDate, string endDate)
        {
            IQueryable<SaleDetail> query = await _genericRepository.MakeQuery();
            var listSale = new List<SaleDetail>();

            try
            {
                DateTime dateStart = DateTime.ParseExact(startDate, "dd/MM/yyyy", new CultureInfo("es-CO"));
                DateTime dateEnd = DateTime.ParseExact(endDate, "dd/MM/yyyy", new CultureInfo("es-CO"));

                listSale = await query
                    .Include(p => p.Product)
                    .Include(s => s.Sale)
                    .Where(sd =>
                        sd.Sale.CreationDate.Value.Date >= dateStart.Date &&
                        sd.Sale.CreationDate.Value.Date <= dateEnd.Date
                     ).ToListAsync();

            }
            catch
            {
                throw;
            }

            return _mapper.Map<List<ReportDto>>(listSale);
        }
    }
}
