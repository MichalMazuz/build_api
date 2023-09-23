using build_api;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lesson2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        static int count = 1;
        static List<Event> events = new List<Event> { new Event { Id = count++, Title = "default event1",start=DateTime.Now }, new Event { Id = count++, Title = "default event2", start = DateTime.Now
        } };


        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return events;
        }

        // GET api/<EventsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Event eve)
        {
            events.Add(new Event { Id = count++, Title = eve.Title, start = eve.start });
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event eve)
        {
            var ev = events.Find(e => e.Id == id);
            if (ev.Id != null)
            {
                ev.Title = eve.Title;
                ev.start = eve.start;
                ev.end = eve.end;
            }
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var eve = events.Find(e => e.Id == id);
            events.Remove(eve);

        }
    }
}
