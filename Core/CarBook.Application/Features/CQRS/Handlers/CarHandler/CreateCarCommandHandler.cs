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
	public class CreateCarCommandHandler
	{
		private readonly IRepository<Car> _repository;

		public CreateCarCommandHandler(IRepository<Car> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateCarCommand command)
		{
			await _repository.CreateAsync(new Car
			{
				BrandID = command.BrandID,
				BıgImageUrl = command.BıgImageUrl,
				Fuel = command.Fuel,
				Luggage = command.Luggage,
				Km = command.Km,
				Model = command.Model,
				Seat = command.Seat,
				CoverImageUrl = command.CoverImageUrl,
				Transmission = command.Transmission
			});
		}
	}
}
