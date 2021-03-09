using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
// https://www.syncfusion.com/blogs/post/how-to-build-crud-rest-apis-with-asp-net-core-3-1-and-entity-framework-core-create-jwt-tokens-and-secure-apis.aspx

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HaandvaerkerController : ControllerBase
    {
        private readonly DbContext _context;
        public HaandvaerkerController(DbContext context)
        {
            _context = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var handvaerker = await _context.FindAsync(id.GetType());

            if (handvaerker == null)
            {
                return NotFound();
            }

            return (ActionResult)handvaerker;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<Haandvaerker>> PostHaandvaerker(Haandvaerker haandvaerker)
        {
            _context.Add(haandvaerker);
            await _context.SaveChangesAsync();

            return CreatedAtAction($"GetHaandvaerker", new {id = haandvaerker.HaandvaerkerId},
                haandvaerker);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Haandvaerker>> DeleteHaandvaerker(int id)
        {
            var haandvaerker = await _context.FindAsync<Haandvaerker>(id);
            if (haandvaerker == null)
            {
                return NotFound();
            }

            _context.Remove(haandvaerker);
            await _context.SaveChangesAsync();

            return haandvaerker;
        }
    }
}
