
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpsCenterApi.Model;
namespace OpsCenterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpsCenterController : ControllerBase
    {
        //Console.WriteLine("inside cont");
        private readonly OpsCenterContext _db;

        public OpsCenterController(OpsCenterContext db)
        {
            _db = db;
        }
        // GET api/opscenter
        //GET api/opscenter/search parameter
        // [HttpGet]
        // public async Task<List<OpsCenter>> Get(int transactionId, int cpuUsage, int responseTime, int errorRate)
        // {
        //     IQueryable<OpsCenter> query = _db.OpsCenters.AsQueryable();

        //     if (transactionId != null)
        //     {
        //         query = query.Where(entry => entry.TransactionId == transactionId);
        //     }

        //     if (cpuUsage != null)
        //     {
        //         query = query.Where(entry => entry.CPUUsage == cpuUsage);
        //     }

        //     if (responseTime != null)
        //     {
        //         query = query.Where(entry => entry.ResponseTime == responseTime);
        //     }

        //     if (errorRate > 0)
        //     {
        //         query = query.Where(entry => entry.ErrorRate >= errorRate);
        //     }

        //     return await query.ToListAsync();
        // }
         [HttpGet]
        public async Task<ActionResult<List<OpsCenter>>> GetAction([FromServices] OpsCenterContext db)
        {
            Console.WriteLine("inside cont");
            var opsCenter = await db.OpsCenters.ToListAsync();
            return opsCenter;
 
        }
        // POST api/animals
        [HttpPost]
        public async Task<ActionResult<OpsCenter>> Post(OpsCenter opsCenter)
        {
        _db.OpsCenters.Add(opsCenter);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetOpsCenter), new { id = opsCenter.TransactionId }, opsCenter);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OpsCenter>> GetOpsCenter(int id)
        {
            var opsCenter = await _db.OpsCenters.FindAsync(id);

            if (opsCenter == null)
            {
                return NotFound();
            }

            return opsCenter;
        }


            // PUT: api/Animals/5
            [HttpPut("{id}")]
            public async Task<IActionResult> Put(int id, OpsCenter opsCenter)
            {
            if (id != opsCenter.TransactionId)
            {
                return BadRequest();
            }

            _db.Entry(opsCenter).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OpsCenterExists(id))
                {
                return NotFound();
                }
                else
                {
                throw;
                }
            }
            return NoContent();
            }
            
            private bool OpsCenterExists(int id)
            {
            return _db.OpsCenters.Any(e => e.TransactionId == id);
            }


            // DELETE: api/Animals/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteOpsCenter(int id)
            {
            var opsCenter = await _db.OpsCenters.FindAsync(id);
            if (opsCenter == null)
            {
                return NotFound();
            }

            _db.OpsCenters.Remove(opsCenter);
            await _db.SaveChangesAsync();

            return NoContent();
            }


    }
}
