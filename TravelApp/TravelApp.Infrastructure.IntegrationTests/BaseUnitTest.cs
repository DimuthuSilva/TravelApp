using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TravelApp.Application.Profiles;
using TravelApp.Persistence;

namespace TravelApp.Infrastructure.IntegrationTests
{
    public class BaseUnitTest
    {
        #region Fields
        protected readonly IMapper _mapper;
        protected readonly TravelAppContext _travelAppContext;
        #endregion

        #region Constructor
        public BaseUnitTest()
        {
            var dbContextOptions = new DbContextOptionsBuilder<TravelAppContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;

            _travelAppContext = new TravelAppContext(dbContextOptions);

            //set the automapper profile
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }
        #endregion
    }
}
