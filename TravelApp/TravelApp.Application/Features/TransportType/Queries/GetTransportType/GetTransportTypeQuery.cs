using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravelApp.Application.Features.TransportType.Queries.GetTransportType
{
    public class GetTransportTypeQuery : IRequest<List<GetTransportTypeVm>>
    {
    }
}
