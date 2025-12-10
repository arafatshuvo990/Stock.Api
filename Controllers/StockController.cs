using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stock.Api.Data;
using Stock.Api.Dtos.Stock;
using Stock.Api.Helpers;
using Stock.Api.Interfaces;
using Stock.Api.Mappper;

namespace Stock.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IStockRepository _stockRepository;
        public StockController(ApplicationDbContext context, IStockRepository stockRepository)
        {
            _context = context;
            _stockRepository = stockRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query) {
            var stocks = await _stockRepository.GetAllStocksAsync(query);
            var stockDto =    stocks.Select(s=>s.ToStockDto());
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStock(int id)
        {
            var stock = await _stockRepository.GetByIdAsync(id);

            if (stock == null)
                return NotFound();

            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStock dto)
        {
            var stockModel = dto.ToStockModel();
            var created = await _stockRepository.CreateAsync(stockModel);

            return CreatedAtAction(nameof(GetStock), new { id = created.Id }, created.ToStockDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateRequestDto dto)
        {
            var updated = await _stockRepository.UpdateAsync(id, dto);

            if (updated == null)
                return NotFound();

            return Ok(updated.ToStockDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _stockRepository.DeleteAsync(id);

            if (deleted == null)
                return NotFound();

            return NoContent();
        }

    }
}
