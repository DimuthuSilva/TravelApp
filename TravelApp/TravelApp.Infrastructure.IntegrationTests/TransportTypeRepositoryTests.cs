using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApp.Application.Contracts.Persistance;
using TravelApp.Persistence.Repositories;
using Xunit;

namespace TravelApp.Infrastructure.IntegrationTests
{
    public class TransportTypeRepositoryTests : BaseUnitTest
    {
        #region Fields
        private readonly IRepository<Domain.Entities.TransportType> _transportTypeRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="TransportTypeRepositoryTests"/> class.
        /// </summary>
        public TransportTypeRepositoryTests()
        {
            _transportTypeRepository = new Repository<Domain.Entities.TransportType>(_travelAppContext);

            //setup test data
            var testData = new List<Domain.Entities.TransportType>
            {
                new Domain.Entities.TransportType
                {
                    Name ="Ferry",
                    IsActive = true,
                },
                new Domain.Entities.TransportType
                {
                    Name = "Flight",
                    IsActive=true
                },
                new Domain.Entities.TransportType
                {
                    Name = "Bus",
                    IsActive=false
                }
            };

            _travelAppContext.TransportTypes.AddRange(testData);
            _travelAppContext.SaveChanges();
        }
        #endregion

        #region Test Methods
        /// <summary>
        /// Shoulds the return active transport types when transport types are available.
        /// </summary>
        [Fact]
        [Trait("Feature", "GetTransportType")]
        public async Task Should_Return_ActiveTransportTypes_When_TransportTypesAreAvailable()
        {
            var result = await _transportTypeRepository.GetAsync(c => c.IsActive == true);

            //assert
            result.Count().ShouldBe(2);
        }
        #endregion
    }
}
