using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandiesController : ControllerBase
    {
        private readonly DataContext _context;

        public CandiesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCandies()
        {
            var candies = await _context.Candies.ToListAsync();
            return Ok(candies);
        }
    }
}