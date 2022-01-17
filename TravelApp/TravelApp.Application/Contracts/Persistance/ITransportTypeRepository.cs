using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TravelApp.Application.Contracts.Persistance
{
    public interface ITransportTypeRepository : IRepository<Domain.Entities.TransportType>
    {
        Task<List<Domain.Entities.FareDetails>> GetFareDetailsAsync(int transportType, DateTime date, string source, string destination);
    }
}
