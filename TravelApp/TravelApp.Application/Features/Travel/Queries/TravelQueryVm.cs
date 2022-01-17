using System;
using System.Collections.Generic;
using System.Text;

namespace TravelApp.Application.Features.Travel.Queries
{
    public class TravelQueryVm
    {
        public DateTime FareDate { get; set; }

        public int Fare { get; set; }

        public string Source { get; set; }

        public string Destination { get; set; }

        public List<TravelDetailsVm> TravelDetails { get; set; }

    }
}
