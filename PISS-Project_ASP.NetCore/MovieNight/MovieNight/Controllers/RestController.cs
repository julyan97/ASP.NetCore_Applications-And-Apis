using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieNight.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieNight.Controllers
{
    [Route("api")]
    [ApiController]
    public class RestController : ControllerBase
    {
        public ApplicationDbContext db { get; set; }

        public RestController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public class UserViewModel
        {
            public string UserName { get; set; }
        }

        // GET: api/<RestController>
        [HttpGet("all/{id}")]
        public ActionResult Get(string id)
        {
            var room = db.ChatRooms.Include(x => x.UserChatRooms) 
                .ThenInclude(x => x.User)
                .FirstOrDefault(x => x.Id == id);

            var users = db.ChatRooms.Include(x => x.UserChatRooms).ThenInclude(x => x.User)
       .FirstOrDefault(x => x.Id == id).UserChatRooms
       .Select(x => x.User.UserName)
       .ToList();

            return Ok(users);
        }

        // GET api/<RestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public ActionResult Search(string userName)
        {
            var rooms = db.ChatRooms.Where(x => x.Owner == userName).ToList();
            return Ok(rooms);
        }
    }
}
