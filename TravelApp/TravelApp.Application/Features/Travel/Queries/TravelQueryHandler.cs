using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelApp.Application.Contracts.Persistance;

namespace TravelApp.Application.Features.Travel.Queries
{
    public class TravelQueryHandler : IRequestHandler<TravelQuery, List<TravelQueryVm>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly ITransportTypeRepository _transportTypeRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="TravelQueryHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        public TravelQueryHandler(ITransportTypeRepository repository, IMapper mapper)
        {
            _transportTypeRepository = repository;
            _mapper = mapper;
        }
        #endregion

        #region Handler
        public async Task<List<TravelQueryVm>> Handle(TravelQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<TravelQueryVm>>(await _transportTypeRepository.GetFareDetailsAsync(
                request.TravelType
                , request.TravelDate
                , request.Source
                , request.Destination));
        }
        #endregion
    }
}
