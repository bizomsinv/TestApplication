using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Responses;
using Test.Data.Routes;
using MediatR;
using Test.Domain.Queries;
using Test.Data.Requests;
using Test.Domain.Commands;

namespace Test.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediator;

        public TestController(IMediator mediator, ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        //[HttpGet(TestRoutes.GetTown)]
        //public async Task<ActionResult<IEnumerable<GetTownResponse>>> GetTown()
        //{
        //    var query = new GetTownQuery("");
        //    var response = await _mediator.Send(query);

        //    return Ok(response);
        //}

        [HttpGet(TestRoutes.GetTownWithQuery)]
        public async Task<ActionResult<IEnumerable<GetTownResponse>>> GetTown([FromQuery(Name = "term")] string term = "")
        {
            var query = new GetTownQuery(term);
            var response = await _mediator.Send(query);

            return Ok(new { results = response});
        }

        [HttpGet(TestRoutes.GetPeople)]
        public async Task<ActionResult<IEnumerable<GetPeopleFromTownQueryResponse>>> GetPeople([FromRoute(Name = "townId")] string townId)
        {
            var query = new GetPeopleFromTownQuery(townId);
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpPost(TestRoutes.AddPeople)]
        public async Task<ActionResult<int>> addPeople([FromBody] AddPeopleRequest request)
        {
            var command = new AddPeopleCommand(request.IdTownBorn, 
                request.IdTownLives, 
                request.Name, 
                request.Surname);
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
