using Stock.Api.Dtos.Stock;
using Stock.Api.Helpers;
using Stock.Api.Models;

namespace Stock.Api.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stocks>> GetAllStocksAsync(QueryObject query);
        Task<Stocks?> GetByIdAsync(int id);
        Task<Stocks> CreateAsync(Stocks stockModel);
        Task<Stocks?> UpdateAsync(int id, UpdateRequestDto stockDto);
        Task<Stocks?> DeleteAsync(int id);
    }
}
