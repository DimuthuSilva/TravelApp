using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TravelApp.Application.Contracts.Persistance;

namespace TravelApp.Application.UnitTests
{
    public static class RepositoryMocks
    {
        /// <summary>
        /// Gets the transport type repository.
        /// </summary>
        /// <returns></returns>
        public static Mock<IRepository<Domain.Entities.TransportType>> GetTransportTypeRepository()
        {
            return new Mock<IRepository<Domain.Entities.TransportType>>();
        }
    }
}
