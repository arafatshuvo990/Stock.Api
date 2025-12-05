using Stock.Api.Dtos;
using Stock.Api.Models;

namespace Stock.Api.Mappper
{
    public static class StockMapper
    {
        public static StockDto ToStockDto(this Stocks stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap
            };
        }
    }
}
