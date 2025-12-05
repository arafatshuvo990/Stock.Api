using Microsoft.AspNetCore.Mvc;
using Stock.Api.Data;
using Stock.Api.Dtos.Stock;
using Stock.Api.Mappper;

namespace Stock.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public StockController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult Index() {
            var stocks = _context.Stock.ToList().Select(s=>s.ToStockDto());
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public ActionResult GetStock(int id) {
            var stock = _context.Stock.Find(id);
            if (stock == null) {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateStock stockDto)
        {
            var stockModel = stockDto.ToStockModel();
            _context.Stock.Add(stockModel);
            _context.SaveChanges();
            var responseDto = stockModel;

            return CreatedAtAction(nameof(GetStock), new { id = stockModel.Id }, responseDto);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateRequestDto stockDto)
        {
            var existingStock = _context.Stock.FirstOrDefault(x=>x.Id==id);
            if (existingStock == null)
            {
                return NotFound();
            }
            existingStock.Symbol = stockDto.Symbol;
            existingStock.CompanyName = stockDto.CompanyName;
            existingStock.Purchase = stockDto.Purchase;
            existingStock.LastDiv = stockDto.LastDiv;
            existingStock.Industry = stockDto.Industry;
            existingStock.MarketCap = stockDto.MarketCap;

            _context.Stock.Update(existingStock);

            _context.SaveChanges();
            return Ok(existingStock.ToStockDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var existingStock = _context.Stock.FirstOrDefault(x => x.Id == id);
            if (existingStock == null)
            {
                return NotFound();
            }
            _context.Stock.Remove(existingStock);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
