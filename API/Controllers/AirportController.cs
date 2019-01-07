using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpGet("AllFlights")]
        public ActionResult<IEnumerable<Flight>> AllFlights()
        {
            List<Flight> flights = _airportDatafactory.Flights.ToList();
            return flights;
        }

        //[Produces("application/xml")]
        //[FilterFormat]
        [HttpGet("{id}")]
        public ActionResult<Flight> Get(int id)
        {
            var flight = _airportDatafactory.Flights.First(x => x.FlightId == id);
            return flight;
        }

        //ReturnSpecificFlights
        [HttpGet("SpecificFlights/{FromLocation}/{ToLocation}")]
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
        //public void Patch([FromBody]JsonPatchDocument<Flight> patch, int id) //patch is the model with updated values
        //{
        //    Flight flight = _airportDatafactory.Flights.FirstOrDefault(x => x.FlightId == id);
        //    patch.ApplyTo(flight, ModelState);

        //    if (!ModelState.IsValid)
        //    {
        //        BadRequest(ModelState);
        //    }

        //    var model = new
        //    {
        //        original = flight,
        //        patched = patch
        //    };

        //    _airportDatafactory.Flights.Update(flight);
        //    _airportDatafactory.SaveChanges();
        //}

        [HttpPut("{id}")]
        public void Put([FromBody] Flight flight)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
        _airportDatafactory.Flights.Update(flight);
        _airportDatafactory.SaveChanges();
        }

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
