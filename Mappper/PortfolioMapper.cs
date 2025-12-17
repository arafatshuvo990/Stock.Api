using Stock.Api.Dtos.Portfolio;
using Stock.Api.Models;

namespace Stock.Api.Mappper
{
    public static class PortfolioMapper
    {
        public static PortfolioDto ToPortfolioDto(this Portfolio portfolioModel)
        {
            return new PortfolioDto
            {
                UserId = portfolioModel.UserId,
                StockId = portfolioModel.StockId,
                TotalQuantity = portfolioModel.TotalQuantity,
                AveragePrice = portfolioModel.AveragePrice,
                CreatedOn = portfolioModel.CreatedOn,
                UpdatedOn = portfolioModel.UpdatedOn
            };
        }

    }
}
