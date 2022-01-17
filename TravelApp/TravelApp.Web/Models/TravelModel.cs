using System;
using System.Collections.Generic;

namespace TravelApp.Web.Models
{
    public class TravelModel
    {
        public DateTime FareDate { get; set; }

        public int Fare { get; set; }

        public string Source { get; set; }

        public string Destination { get; set; }

        public List<TravelDetailsModel> TravelDetails { get; set; }
    }
}
