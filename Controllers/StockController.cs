using Microsoft.AspNetCore.Mvc;
using Stock.Api.Data;
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
    }
}
