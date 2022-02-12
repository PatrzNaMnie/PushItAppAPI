using Microsoft.AspNetCore.Mvc;
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
    public class HistoricalController : ControllerBase
    {

        private readonly PushITAppContext db;

        public HistoricalController (PushITAppContext db)
        {
            this.db = db;
        }

        // GET: api/<HistoricalController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.Historicals.ToList());
        }

        // GET api/<HistoricalController>/5
        [HttpGet("{UserId}")]
        public IActionResult Get(int UserId)
        {
            return Ok(db.Historicals.Where(p=>p.UserId == UserId).ToList());
        }

        // POST api/<HistoricalController>
        [HttpPost]
        public IActionResult Post([FromBody] Historical historical)
        {
            db.Historicals.Add(
                new Historical
                {
                    UserId = historical.UserId,
                    PushUps = historical.PushUps,
                    Date = historical.Date

                }
                );
            db.SaveChanges();

            return Ok();
        }

    }
}
