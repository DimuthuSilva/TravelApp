using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TravelApp.Domain.Entities;

namespace TravelApp.Persistence
{
    public class TravelAppContext : DbContext
    {
        public DbSet<TransportType> TransportTypes { get; set; }

        public DbSet<TransportTypeDetails> TransportTypeDetails { get; set; }

        public DbSet<FareDetails> FareDetails { get; set; }

        public DbSet<TravelDetails> TravelDetails { get; set; }

        public TravelAppContext(DbContextOptions<TravelAppContext> options) : base(options)
        {

        }
    }
}
