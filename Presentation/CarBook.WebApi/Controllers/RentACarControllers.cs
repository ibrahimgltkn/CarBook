using CarBook.Application.Features.Mediator.Queries.RentACarQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarControllers : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentACarControllers(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> GetRentACarListyByLocation(GetRentACarQuery query)
        {
            var values = await _mediator.Send(query);
            return Ok(values);
        }
    }
}
