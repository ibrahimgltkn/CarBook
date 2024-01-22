﻿using CarBook.Application.Features.CQRS.Commands.CarCommand;
using CarBook.Application.Features.CQRS.Handlers.CarHandler;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarsController : ControllerBase
	{
		private readonly GetCarQueryHandler _getCarQueryHandler;
		private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
		private readonly CreateCarCommandHandler _createCarCommandHandler;
		private readonly UpdateCarCommandHandler _updateCarCommandHandler;
		private readonly RemoveCarCommandHandler _removeCarCommandHandler;
		private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;


		public CarsController(GetCarQueryHandler getCarQueryHandler,
            GetCarByIdQueryHandler getCarByIdQueryHandler,
            CreateCarCommandHandler createCarCommandHandler,
            UpdateCarCommandHandler updateCarCommandHandler,
            RemoveCarCommandHandler removeCarCommandHandler,
            GetCarWithBrandQueryHandler getCarWithBrandQueryHandler)
        {
            _getCarQueryHandler = getCarQueryHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _createCarCommandHandler = createCarCommandHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
            _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
        }

        [HttpGet]
		public async Task<IActionResult> CarList()
		{
			var values = await _getCarQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCar(int id)
		{
			var value = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateCar(CreateCarCommand command)
		{
			await _createCarCommandHandler.Handle(command);
			return Ok("Araç Eklendi.");
		}

		[HttpDelete]
		public async Task<IActionResult> RemoveCar(int id)
		{
			await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
			return Ok("Araç Silindi.");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
		{
			await _updateCarCommandHandler.Handle(command);
			return Ok("Araç Güncellendi.");
		}

		[HttpGet("GetCarWithBrand")]
		public IActionResult GetCarWithBrand()
		{
			var values = _getCarWithBrandQueryHandler.Handle();
			return Ok(values);
		}
	}
}
