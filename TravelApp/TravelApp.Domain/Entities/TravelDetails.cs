using System;
using System.Collections.Generic;
using System.Text;

namespace TravelApp.Domain.Entities
{
    public class TravelDetails : BaseEntity
    {
        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public string DepartureTerminal { get; set; }

        public string ArrivalTerminal { get; set; }

        public FareDetails FareDetails { get; set; }
    }
}
