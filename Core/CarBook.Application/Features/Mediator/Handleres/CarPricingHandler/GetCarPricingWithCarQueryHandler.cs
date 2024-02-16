﻿using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResult;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handleres.CarPricingHandler
{
    public class GetCarPricingWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
    {
        private readonly ICarPricingRepository _repository;

        public GetCarPricingWithCarQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarPricingWithCars();
            return values.Select(x => new GetCarPricingWithCarQueryResult
            {
                Amount = x.Amount,
                CarPricingId = x.CarPricingID,
                Brand = x.Car.Brand.Name,
                CoverImageUrl = x.Car.CoverImageUrl,
                Model = x.Car.Model,
                CarID = x.Car.CarID
            }).ToList();
        }
    }
}
