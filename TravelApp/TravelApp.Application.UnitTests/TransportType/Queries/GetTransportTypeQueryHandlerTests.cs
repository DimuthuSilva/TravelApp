using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using TravelApp.Application.Contracts.Persistance;
using TravelApp.Application.Features.TransportType.Queries.GetTransportType;
using Xunit;

namespace TravelApp.Application.UnitTests.TransportType.Queries
{
    public class GetTransportTypeQueryHandlerTests : BaseUnitTest
    {
        #region Fields
        private readonly Mock<IRepository<Domain.Entities.TransportType>> _mockTransportTypeRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="GetTransportTypeQueryHandlerTests"/> class.
        /// </summary>
        public GetTransportTypeQueryHandlerTests()
        {
            _mockTransportTypeRepository = RepositoryMocks.GetTransportTypeRepository();
        }
        #endregion

        #region Test Methods
        /// <summary>
        /// Shoulds the return active transport types when transport types are available.
        /// </summary>
        [Fact]
        [Trait("Feature", "GetTransport")]
        public async Task Should_Return_ActiveTransportTypes_When_TransportTypesAreAvailable()
        {
            //Arrange
            _mockTransportTypeRepository.Setup(c => c.GetAsync(It.IsAny<Expression<Func<Domain.Entities.TransportType, bool>>>()
                , It.IsAny<Func<IQueryable<Domain.Entities.TransportType>, IOrderedQueryable<Domain.Entities.TransportType>>>()
                , String.Empty))
                .ReturnsAsync(new List<Domain.Entities.TransportType>
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
                    }
                });

            //Act
            var handler = new GetTransportTypeQueryHandler(
                _mockTransportTypeRepository.Object
                , _mapper);

            //Assert
            var result = await handler.Handle(new GetTransportTypeQuery(), CancellationToken.None);

            result.Count.ShouldBe(2);
        }

        /// <summary>
        /// Shoulds the not return active transport types when transport types are not available.
        /// </summary>
        [Fact]
        [Trait("Feature", "GetTransport")]
        public async Task Should_NotReturn_ActiveTransportTypes_When_TransportTypesAreNotAvailable()
        {
            //Arrange
            _mockTransportTypeRepository.Setup(c => c.GetAsync(It.IsAny<Expression<Func<Domain.Entities.TransportType, bool>>>()
                , It.IsAny<Func<IQueryable<Domain.Entities.TransportType>, IOrderedQueryable<Domain.Entities.TransportType>>>()
                , String.Empty))
                .ReturnsAsync(new List<Domain.Entities.TransportType>());

            //Act
            var handler = new GetTransportTypeQueryHandler(
                _mockTransportTypeRepository.Object
                , _mapper);

            //Assert
            var result = await handler.Handle(new GetTransportTypeQuery(), CancellationToken.None);

            result.Count.ShouldBe(0);
        }
        #endregion
    }
}
