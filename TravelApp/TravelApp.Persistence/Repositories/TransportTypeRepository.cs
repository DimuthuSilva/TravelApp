using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApp.Application.Contracts.Persistance;
using Z.EntityFramework.Plus;

namespace TravelApp.Persistence.Repositories
{
    public class TransportTypeRepository : Repository<Domain.Entities.TransportType>, ITransportTypeRepository
    {
        #region Fields
        private readonly TravelAppContext _context;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="TransportTypeRepository"/> class.
        /// </summary>
        /// <param name="travelAppContext">The travel application context.</param>
        public TransportTypeRepository(TravelAppContext travelAppContext) : base(travelAppContext)
        {
            _context = travelAppContext;
        }
        #endregion

        #region Repository Methods
        /// <summary>
        /// Gets the fare details asynchronous.
        /// </summary>
        /// <param name="transportType">Type of the transport.</param>
        /// <param name="date">The date.</param>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <returns></returns>
        public async Task<List<Domain.Entities.FareDetails>> GetFareDetailsAsync(int transportType, DateTime date, string source, string destination)
        {
            //get fare detials for the above parameters
            var query = _context.TransportTypeDetails
                .IncludeFilter(t => t.FareDetails
                    .Where(f => f.FareDate == date && f.IsActive == true && f.Source == source && f.Destination == destination))
                .IncludeFilter(t => t.FareDetails
                    .Where(f => f.FareDate == date && f.IsActive == true && f.Source == source && f.Destination == destination)
                    .SelectMany(ft => ft.TravelDetails))
                .Where(t => t.TransportType.Id == transportType && t.TransportType.IsActive == true);


            var result = await query.ToListAsync();

            //select the fare details
            return result.SelectMany(t => t.FareDetails).ToList();
        }
        #endregion

    }
}
