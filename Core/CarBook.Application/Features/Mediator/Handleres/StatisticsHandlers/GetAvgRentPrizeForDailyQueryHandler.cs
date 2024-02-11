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
    public class GetAvgRentPrizeForDailyQueryHandler : IRequestHandler<GetAvgRentPrizeForDailyQuery, GetAvgRentPrizeForDailyQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAvgRentPrizeForDailyQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAvgRentPrizeForDailyQueryResult> Handle(GetAvgRentPrizeForDailyQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetAvgRentPrizeForDaily();
            return new GetAvgRentPrizeForDailyQueryResult
            {
                AvgPriceForDaily = value
            };
        }
    }
}
