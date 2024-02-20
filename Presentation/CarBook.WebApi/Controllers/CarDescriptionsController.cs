using CarBook.Application.Features.Mediator.Queries.CarDescriptionQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarDescriptionsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CarDescriptionsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("CarDescriptionByCarId")]
		public async Task<IActionResult> CarDescriptionByCarId(int id)
		{
			var values =  _mediator.Send(new GetCarDescriptionByCarIdQuery(id));
			return Ok(values.Result);
		}


	}
}
