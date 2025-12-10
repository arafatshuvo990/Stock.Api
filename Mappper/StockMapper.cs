using Stock.Api.Dtos.Stock;
using Stock.Api.Mapper;
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
                MarketCap = stockModel.MarketCap,
                Comments = stockModel.Comments?.Select(c => c.ToCommentDto()).ToList()
            };
        }
        public static Stocks ToStockModel(this CreateStock dto)
        {
            return new Stocks
            {
                Symbol = dto.Symbol,
                CompanyName = dto.CompanyName,
                Purchase = dto.Purchase,
                LastDiv = dto.LastDiv,
                Industry = dto.Industry,
                MarketCap = dto.MarketCap
            };
        }

    }
}
