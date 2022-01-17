using AutoMapper;
using TravelApp.Application.Features.TransportType.Queries.GetTransportType;
using TravelApp.Application.Features.Travel.Queries;

namespace TravelApp.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.TransportType, GetTransportTypeVm>();
            CreateMap<Domain.Entities.FareDetails, TravelQueryVm>();
            CreateMap<Domain.Entities.TravelDetails, TravelDetailsVm>();
        }
    }
}
