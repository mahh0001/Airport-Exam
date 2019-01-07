using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/airport")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private readonly AirportDataFactory _airportDatafactory;
        public AirportController(AirportDataFactory airportDataFactory)
        {
            _airportDatafactory = airportDataFactory;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Flight>> Get()
        {
            List<Flight> flights = _airportDatafactory.Flights.ToList();
            return flights;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            //var value = _datafactory.Table.First(x => x.Id == Id);
            //return value;
            return "value";
        }

        // POST api/values
        [HttpPost("NewFlight")]
        public void Post([FromBody] Flight flight)
        {
            _airportDatafactory.Add(flight);
            _airportDatafactory.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }

            //_db.Table.Update(value);
            //_db.SaveChanges();
        }

        //[HttpPatch("{id}")] 
        //public void Patch([FromBody]JsonPatchDocument<Model> patch, int id) //patch is the model with updated values
        //{
        //    Model value = _db.Table.FirstOrDefault(x => x.Id == id);
        //    patch.ApplyTo(value, ModelState);

        //    if (!ModelState.IsValid)
        //    {
        //        BadRequest(ModelState);
        //    }

        //    var model = new
        //    {
        //        original = value,
        //        patched = patch
        //    };

        //    _db.Table.Update(value);
        //    _db.SaveChanges();
        //}

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //Model value = _db.Table.First(x => x.Id == id);
            //_db.Table.Remove(value);
            //_db.SaveChanges();
        }
    }
}
