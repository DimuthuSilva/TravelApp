using System;

namespace TravelApp.Web.Models
{
    public class SearchModel
    {
        public int TravelType { get; set; }

        public DateTime TravelDate { get; set; }

        public string Source { get; set; }

        public string Destination { get; set; }
    }
}
