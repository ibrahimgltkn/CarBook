using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Handlers.BrandHandler;
using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BrandsController : ControllerBase
	{
		private readonly CreateBrandCommandHandler _createBrandCommandHandler;
		private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
		private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;
		private readonly GetBrandQueryHandler _getBrandQueryHandler;
		private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;

		public BrandsController(CreateBrandCommandHandler createBrandCommandHandler, 
			UpdateBrandCommandHandler updateBrandCommandHandler, 
			RemoveBrandCommandHandler removeBrandCommandHandler, 
			GetBrandQueryHandler getBrandQueryHandler, 
			GetBrandByIdQueryHandler getBrandByIdQueryHandler)
		{
			_createBrandCommandHandler = createBrandCommandHandler;
			_updateBrandCommandHandler = updateBrandCommandHandler;
			_removeBrandCommandHandler = removeBrandCommandHandler;
			_getBrandQueryHandler = getBrandQueryHandler;
			_getBrandByIdQueryHandler = getBrandByIdQueryHandler;
		}

		[HttpGet]
		public async Task<IActionResult> BransList()
		{
			var values = await _getBrandQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetBrand(int id)
		{
			var value = await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
		{
			await _createBrandCommandHandler.Handle(command);
			return Ok("Marka eklendi.");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveBrand(int id)
		{
			await _removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
			return Ok("Marka Silindi.");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
		{
			await _updateBrandCommandHandler.Handle(command);
			return Ok("Marka Güncellendi.");
		}
	}
}
