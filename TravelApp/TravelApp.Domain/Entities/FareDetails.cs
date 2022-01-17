using System;
using System.Collections.Generic;

namespace TravelApp.Domain.Entities
{
    public class FareDetails : BaseEntity
    {
        public DateTime FareDate { get; set; }

        public int Fare { get; set; }

        public string Source { get; set; }

        public string Destination { get; set; }

        public bool IsActive { get; set; }

        public List<TravelDetails> TravelDetails { get; set; }
    }
}
