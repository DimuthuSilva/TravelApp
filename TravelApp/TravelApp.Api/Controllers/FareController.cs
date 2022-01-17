using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelApp.Application.Features.Travel.Queries;

namespace TravelApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FareController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="TransportTypeController" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public FareController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region API Methods
        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>List<TravelQueryVm></returns>
        [HttpGet("GetList")]
        [ProducesResponseType(typeof(List<TravelQueryVm>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<TravelQueryVm>>> GetList([FromQuery] TravelQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        #endregion
    }
}
