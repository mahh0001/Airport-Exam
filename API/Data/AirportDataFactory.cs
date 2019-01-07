using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class AirportDataFactory : DbContext
    {
        public AirportDataFactory(DbContextOptions<AirportDataFactory> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Flight> Flights { get; set; }
    }
}
