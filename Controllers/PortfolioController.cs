using Microsoft.AspNetCore.Mvc;
using Stock.Api.Data;

namespace Stock.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PortfolioController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetPortfolios()
        {
            var portfolios = _context.Portfolio.ToList();
            return Ok(portfolios);
        }
        [HttpGet("{id}")]
        public IActionResult GetPortfolio(int id)
        {
            var portfolio = _context.Portfolio.FirstOrDefault(p => p.Id == id);

            if (portfolio == null)
            {
                return NotFound();
            }

            return Ok(portfolio);
        }

    }
}
