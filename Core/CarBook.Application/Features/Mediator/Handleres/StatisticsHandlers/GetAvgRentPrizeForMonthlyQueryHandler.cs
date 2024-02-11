using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResult;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handleres.StatisticsHandlers
{
    public class GetAvgRentPrizeForMonthlyQueryHandler : IRequestHandler<GetAvgRentPrizeForMonthlyQuery, GetAvgRentPrizeForMonthlyQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAvgRentPrizeForMonthlyQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAvgRentPrizeForMonthlyQueryResult> Handle(GetAvgRentPrizeForMonthlyQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetAvgRentPrizeForMonthly();
            return new GetAvgRentPrizeForMonthlyQueryResult
            {
                AvgPriceForMonthly = value
            };
        }
    }
}
