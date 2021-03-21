using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.DB;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
// https://www.syncfusion.com/blogs/post/how-to-build-crud-rest-apis-with-asp-net-core-3-1-and-entity-framework-core-create-jwt-tokens-and-secure-apis.aspx

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HaandvaerkerController : ControllerBase
    {
        private readonly dbContext _context;
        private readonly IServiceProvider _serviceProvider;
        public HaandvaerkerController(dbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        // GET api/<ValuesController>/5
        [HttpGet("byId")]
        public async Task<ActionResult> GetbyID([FromQuery]int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            using (var context = new dbContext(
                _serviceProvider.GetRequiredService<
                    DbContextOptions<dbContext>>()))
            {
                var hv = context.Haandvaerkers.Find(id);
                if (hv == null)
                {
                    return NotFound();
                }

                return Ok(hv);
            }
        }

        [HttpGet("GetallHandvaerker")]
        public async Task<IActionResult> GetAll()
        {
            using (var context = new dbContext(
                _serviceProvider.GetRequiredService<
                    DbContextOptions<dbContext>>()))
            {
                var hv = await context.Haandvaerkers.ToListAsync();
                if (hv == null)
                {
                    return NotFound();
                }

                return Ok(hv);
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<Haandvaerker>> PostHaandvaerker([FromBody] Haandvaerker haandvaerker)
            //([FromQuery]int haandvaerkerId, [FromQuery]string hvEfternavn,
            //[FromQuery] string hvFagomraade, [FromQuery] string hvFornavn)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            await _context.Haandvaerkers.AddAsync(haandvaerker);
            await _context.SaveChangesAsync();

            return CreatedAtAction($"GetHaandvaerker", new {id = haandvaerker.HaandvaerkerId},
                   haandvaerker);

            //using (var context = new dbContext(
            //    _serviceProvider.GetRequiredService<
            //        DbContextOptions<dbContext>>()))
            //{
            //    var haandvaerker = new Haandvaerker();
            //    haandvaerker.HaandvaerkerId = haandvaerkerId;
            //    haandvaerker.HVEfternavn = hvEfternavn;
            //    haandvaerker.HVFagomraade = hvFagomraade;
            //    haandvaerker.HVFornavn = hvFornavn;

            //    //context.Database.ExecuteSqlRaw("USE Haandvaerker");
            //    //context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Haandvaerker ON;");
            //    context.Database.ExecuteSqlRaw("USE Haandvaerker;" +
            //                                   "SET IDENTITY_INSERT Haandvaerker ON; " +
            //    "Insert into Haandvaerker Values( @HVAnsaettelsedato , @HVEfternavn, @HVFagomraade, @HVFornavn)",
            //    //new SqlParameter("HaandvaerkerId", haandvaerkerId),
            //    new SqlParameter("HVAnsaettelsedato", DateTime.Now),
            //    new SqlParameter("HVEfternavn", hvEfternavn),
            //    new SqlParameter("HVFagomraade", hvFagomraade),
            //    new SqlParameter("hvFornavn", hvFornavn)
            //    );

            //    //context.Haandvaerkers.Add(haandvaerker);

            //    //await context.SaveChangesAsync();
            //    //context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Haandvaerker OFF;");

            //    return CreatedAtAction($"GetHaandvaerker",
            //        haandvaerker);
            //}
        }

        // PUT api/<ValuesController>/5
        [HttpPut("ChangeFagområde")]
        public async Task<IActionResult> Put([FromQuery] int id, [FromQuery]string fagomraade)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            using (var context = new dbContext(
                _serviceProvider.GetRequiredService<
                    DbContextOptions<dbContext>>()))
            {
                var hv = context.Haandvaerkers.Find(id);
                if (hv == null)
                {
                    return NotFound();
                }

                hv.HVFagomraade = fagomraade;
                context.Update(hv);
                await context.SaveChangesAsync();
                return Ok("Changed Haandvaerker= " + hv.HVFornavn + ", " + hv.HVFagomraade + ", ID = " + hv.HaandvaerkerId);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("ByID")]
        public async Task<ActionResult<Haandvaerker>> DeleteHaandvaerker([FromQuery]int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            using (var context = new dbContext(
                _serviceProvider.GetRequiredService<
                    DbContextOptions<dbContext>>()))
            {
                var hv = context.Haandvaerkers.Find(id);
                if (hv == null)
                {
                    return NotFound();
                }

                context.Remove(hv);
                await context.SaveChangesAsync();
                return Ok("Deleted Haandvaerker= " + hv.HVFornavn +  ", " + hv.HVEfternavn + ", ID = " + hv.HaandvaerkerId);
            }
        }
    }
}
