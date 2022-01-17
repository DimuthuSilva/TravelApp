using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TravelApp.Application.Contracts.Persistance;

namespace TravelApp.Application.Features.TransportType.Queries.GetTransportType
{
    public class GetTransportTypeQueryHandler : IRequestHandler<GetTransportTypeQuery, List<GetTransportTypeVm>>
    {
        #region Fields
        private readonly IRepository<Domain.Entities.TransportType> _repository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="GetTransportTypeQueryHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        public GetTransportTypeQueryHandler(IRepository<Domain.Entities.TransportType> repository
            , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        #endregion

        #region Handler
        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public async Task<List<GetTransportTypeVm>> Handle(GetTransportTypeQuery request, CancellationToken cancellationToken)
        {
            //get transport types
            return _mapper.Map<List<GetTransportTypeVm>>(await _repository.GetAsync(c => c.IsActive == true));
        }
        #endregion
    }
}
