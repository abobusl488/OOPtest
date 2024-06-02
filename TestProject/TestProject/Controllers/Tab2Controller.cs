using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Context;
using TestProject.Models;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tab2Controller : ControllerBase
    {
        private readonly MyContext _context;

        public Tab2Controller(MyContext context)
        {
            _context = context;
        }

        // GET: api/Tab2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tab2>>> GetTab2()
        {
            return await _context.Tab2.Include(t => t.Tab1).ToListAsync();
        }

        // GET: api/Tab2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tab2>> GetTab2(long id)
        {
            var tab2 = await _context.Tab2.Include(t => t.Tab1).FirstOrDefaultAsync(t => t.Id == id);

            if (tab2 == null)
            {
                return NotFound();
            }

            return tab2;
        }
    }
}