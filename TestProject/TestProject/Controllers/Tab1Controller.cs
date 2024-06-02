using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestProject.Context;
using TestProject.Models;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tab1Controller : ControllerBase
    {
        private readonly MyContext _context;

        public Tab1Controller(MyContext context)
        {
            _context = context;
        }

        // GET: api/Tab1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tab1>>> GetTab1()
        {
            return await _context.Tab1.ToListAsync();
        }

        // GET: api/Tab1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tab1>> GetTab1(long id)
        {
            var tab1 = await _context.Tab1.FindAsync(id);

            if (tab1 == null)
            {
                return NotFound();
            }

            return tab1;
        }
    }
}