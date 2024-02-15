using CarBook.Application.Features.Mediator.Queries.RentACarQueries;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentACarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetRentACarListyByLocation(int locationID, bool available)
        {
            GetRentACarQuery getRentACarQuery = new GetRentACarQuery()
            {
                LocationID = locationID,
                Available = available
            };
            var values = await _mediator.Send(getRentACarQuery);
            return Ok(values);
        }
    }
}
