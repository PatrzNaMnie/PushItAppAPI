using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PushItAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PushItAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PushUpsController : ControllerBase
    {

        private readonly PushITAppContext db;

        public PushUpsController(PushITAppContext db)
        {
            this.db = db;
        }

        // GET: api/<PushUpsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.PushUps.ToList());
        }

        // GET api/<PushUpsController>/5
        [HttpGet("{userID}")]
        public IActionResult GetByUserId(int userID)
        {
            var test = db.PushUps.FirstOrDefault(p => p.UserId == userID).CompletedPushUps;
            return Ok(test) ;
        }

        // POST api/<PushUpsController>
        [HttpPost]
        public IActionResult Post([FromBody] PushUp pushUp)
        {
            db.PushUps.Add(pushUp);
            db.SaveChanges();

            return CreatedAtAction(
                nameof(GetByUserId),
                new { id = pushUp.Id },
                pushUp
                );
        }

        // PUT api/<PushUpsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, PushUp pushUp)
        {

            if (id != pushUp.Id) return BadRequest();

            db.Entry(pushUp).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch
            {
                if (db.PushUps.Find(id) == null)
                    return NotFound();
                throw;
            }


            return NoContent();
        }

        // DELETE api/<PushUpsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
