using CarBook.Application.Features.CQRS.Commands.CarCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandler
{
	public class UpdateCarCommandHandler
	{
		private readonly IRepository<Car> _repository;

		public UpdateCarCommandHandler(IRepository<Car> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateCarCommand command)
		{
			var values = await _repository.GetByIdAsync(command.CarID);
			values.Fuel = command.Fuel;
			values.Transmission = command.Transmission;
			values.BıgImageUrl = command.BıgImageUrl;
			values.BrandID = command.BrandID;
			values.CoverImageUrl = command.CoverImageUrl;
			values.Km = command.Km;
			values.Luggage = command.Luggage;
			values.Model = command.Model;
			values.Seat = command.Seat;

			await _repository.UpdateAsync(values);
		}
	}
}
