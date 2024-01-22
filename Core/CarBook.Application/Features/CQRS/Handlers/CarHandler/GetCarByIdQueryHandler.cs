using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandler
{
	public class GetCarByIdQueryHandler
	{
		private readonly IRepository<Car> _repository;

		public GetCarByIdQueryHandler(IRepository<Car> repository)
		{
			_repository = repository;
		}

		public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
		{
			var value = await _repository.GetByIdAsync(query.Id);
			return new GetCarByIdQueryResult
			{
				BrandID = value.BrandID,
				BıgImageUrl = value.BıgImageUrl,
				CarID = value.CarID,
				CoverImageUrl = value.CoverImageUrl,
				Fuel = value.Fuel,
				Km = value.Km,
				Luggage = value.Luggage,
				Model = value.Model,
				Seat = value.Seat,
				Transmission = value.Transmission				
			};
		}
	}
}
