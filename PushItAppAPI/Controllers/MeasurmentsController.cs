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
    public class MeasurmentsController : ControllerBase
    {

        private readonly PushITAppContext db;

        public MeasurmentsController(PushITAppContext db)
        {
            this.db = db;
        }

        // GET: api/<MeasurmentsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.Measurements.ToList());
        }

        // GET api/<MeasurmentsController>/5
        [HttpGet("{UserID}")]
        public IActionResult GetByUserId(int UserID)
        {
            return Ok(db.Measurements.FirstOrDefault(p => p.UserId == UserID));
        }

        // POST api/<MeasurmentsController>
        [HttpPost]
        public IActionResult Post([FromBody] Measurement measurement)
        {
            db.Measurements.Add(
               new Measurement
               {
                   UserId = measurement.UserId,
                   Age = measurement.Age,
                   Weight = measurement.Weight,
                   Height = measurement.Height,
                   Bmi = measurement.Bmi,
                   Bmr = measurement.Bmr,
                   Chest = measurement.Chest,
                   Arms = measurement.Arms,
                   Waist = measurement.Waist

               }
               );
            db.SaveChanges();

            return Ok();
        }
    }
}
