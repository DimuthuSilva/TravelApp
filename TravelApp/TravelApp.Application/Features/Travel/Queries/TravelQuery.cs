using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravelApp.Application.Features.Travel.Queries
{
    public class TravelQuery : IRequest<List<TravelQueryVm>>
    {
        public int TravelType { get; set; }

        public DateTime TravelDate { get; set; }

        public string Source { get; set; }

        public string Destination { get; set; }
    }
}
