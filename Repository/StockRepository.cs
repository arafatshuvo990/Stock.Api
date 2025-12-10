using Microsoft.EntityFrameworkCore;
using Stock.Api.Data;
using Stock.Api.Dtos.Stock;
using Stock.Api.Helpers;
using Stock.Api.Interfaces;
using Stock.Api.Models;

namespace Stock.Api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Stocks>> GetAllStocksAsync(QueryObject query)
        {
            var stockQuery =   _context.Stock.Include(c=>c.Comments).AsQueryable();
            if (!string.IsNullOrEmpty(query.Symbol))
            {
                stockQuery = stockQuery.Where(s => s.Symbol.Contains(query.Symbol));
            }
            if (!string.IsNullOrEmpty(query.CompanyName))
            {
                stockQuery = stockQuery.Where(s => s.CompanyName.Contains(query.CompanyName));
            }
            if (!string.IsNullOrWhiteSpace(query.Symbol))
            {
                stockQuery = stockQuery.Where(s => s.Symbol.Contains(query.Symbol));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                {
                    stockQuery = query.IsDecsending ? stockQuery.OrderByDescending(s => s.Symbol) : stockQuery.OrderBy(s => s.Symbol);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;


            return await stockQuery.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Stocks?> GetByIdAsync(int id)
        {
            return await _context.Stock.Include(c => c.Comments).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Stocks> CreateAsync(Stocks stockModel)
        {
            await _context.Stock.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stocks?> UpdateAsync(int id, UpdateRequestDto stockDto)
        {
            var existingStock = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);

            if (existingStock == null)
                return null;

            existingStock.Symbol = stockDto.Symbol;
            existingStock.CompanyName = stockDto.CompanyName;
            existingStock.Purchase = stockDto.Purchase;
            existingStock.LastDiv = stockDto.LastDiv;
            existingStock.Industry = stockDto.Industry;
            existingStock.MarketCap = stockDto.MarketCap;

            await _context.SaveChangesAsync();
            return existingStock;
        }

        public async Task<Stocks?> DeleteAsync(int id)
        {
            var existingStock = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);

            if (existingStock == null)
                return null;

            _context.Stock.Remove(existingStock);
            await _context.SaveChangesAsync();

            return existingStock;
        }
    }
}
