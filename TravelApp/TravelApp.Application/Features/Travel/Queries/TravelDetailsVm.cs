using System;
using System.Collections.Generic;
using System.Text;

namespace TravelApp.Application.Features.Travel.Queries
{
    public class TravelDetailsVm
    {
        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public string DepartureTerminal { get; set; }

        public string ArrivalTerminal { get; set; }
    }
}
