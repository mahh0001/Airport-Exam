using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            if (flights == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
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

        [HttpPut("{id}")]
        public void Put([FromBody] Flight flight)
        {
            var saved = false;
            while (!saved)
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        BadRequest(ModelState);
                    }
                    _airportDatafactory.Flights.Update(flight);
                    _airportDatafactory.SaveChanges();
                    saved = true;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var valueToBeSaved = ex.Entries.Single();
                    valueToBeSaved.OriginalValues.SetValues(valueToBeSaved.GetDatabaseValues());
                    _airportDatafactory.SaveChanges();
                    saved = true;
                }
            }
        }

        [HttpGet("alldeparturesandarrivals")]
        public List<Flight> AllDeparturesAndArrivals()
        {
            List<Flight> flights = _airportDatafactory.Flights.ToList();
            return flights;
        }
    }
}
