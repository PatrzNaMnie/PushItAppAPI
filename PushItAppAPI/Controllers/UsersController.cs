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
    public class UsersController : ControllerBase
    {

        private readonly PushITAppContext db;

        public UsersController(PushITAppContext db)
        {
            this.db = db;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.Users.ToList());
        }

        // GET api/<UsersController>/5
        [HttpGet("{hashCode}")]
        public IActionResult GetByHashCode(string hashCode)
        {
            var test = db.Users.FirstOrDefault(p => p.HashCode == hashCode).Id;
            return Ok(test);
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            db.Users.Add(
                new User
                {
                    HashCode = user.HashCode
                }
                );
            db.SaveChanges();

            return Ok();
        }
    }
}
