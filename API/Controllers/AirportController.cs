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

        [HttpGet]
        public ActionResult<IEnumerable<Flight>> AllFlights()
        {
            List<Flight> flights = _airportDatafactory.Flights.ToList();
            return flights;
        }

        [HttpGet("{id}")]
        public ActionResult<Flight> Get(int id)
        {
            var flight = _airportDatafactory.Flights.First(x => x.FlightId == id);
            return flight;
        }

        //ReturnSpecificFlights
        [HttpGet("SpecificFlights")]
        public List<Flight> GetSpecificFlights(string FromLocation, string ToLocation) //MAY CHANGE
        {
            List<Flight> specificFlights = new List<Flight>();
            foreach (var item in _airportDatafactory.Flights)
            {
                if (item.FromLocation == FromLocation && item.ToLocation == ToLocation)
                {
                    specificFlights.Add(item);
                }
            }
            return specificFlights;
        }

        [HttpPost("NewFlight")]
        public void Post([FromBody] Flight flight)
        {
            _airportDatafactory.Add(flight);
            _airportDatafactory.SaveChanges();
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

        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        BadRequest(ModelState);
        //    }
        //_db.Table.Update(value);
        //_db.SaveChanges();
        //}

        // DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //Model value = _db.Table.First(x => x.Id == id);
        //_db.Table.Remove(value);
        //_db.SaveChanges();
        //}
    }
}
