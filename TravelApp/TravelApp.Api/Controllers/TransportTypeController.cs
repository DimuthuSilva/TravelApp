using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelApp.Application.Features.TransportType.Queries.GetTransportType;

namespace TravelApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportTypeController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="TransportTypeController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public TransportTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Api Methods
        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetList")]
        [ProducesResponseType(typeof(List<GetTransportTypeVm>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetList()
        {
            var transportTypeList = await _mediator.Send(new GetTransportTypeQuery());

            return Ok(transportTypeList);
        }
        #endregion
    }
}
