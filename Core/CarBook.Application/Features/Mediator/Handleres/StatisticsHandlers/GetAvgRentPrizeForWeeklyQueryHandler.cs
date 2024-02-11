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
    public class GetAvgRentPrizeForWeeklyQueryHandler : IRequestHandler<GetAvgRentPrizeForWeeklyQuery, GetAvgRentPrizeForWeeklyQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAvgRentPrizeForWeeklyQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAvgRentPrizeForWeeklyQueryResult> Handle(GetAvgRentPrizeForWeeklyQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetAvgRentPrizeForWeekly();
            return new GetAvgRentPrizeForWeeklyQueryResult
            {
                AvgPriceForWeekly = value
            };
        }
    }
}
