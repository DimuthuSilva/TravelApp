using System;

namespace TravelApp.Web.Models
{
    public class TravelDetailsModel
    {
        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public string DepartureTerminal { get; set; }

        public string ArrivalTerminal { get; set; }
    }
}
