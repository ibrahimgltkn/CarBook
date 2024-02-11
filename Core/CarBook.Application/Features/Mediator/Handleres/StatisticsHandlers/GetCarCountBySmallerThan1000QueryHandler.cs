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
    public class GetCarCountBySmallerThan1000QueryHandler : IRequestHandler<GetCarCountBySmallerThan1000Query, GetCarCountBySmallerThan1000QueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountBySmallerThan1000QueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountBySmallerThan1000QueryResult> Handle(GetCarCountBySmallerThan1000Query request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountBySmallerThan1000();
            return new GetCarCountBySmallerThan1000QueryResult
            {
                CarCountBySmallerThan1000 = value
            };
        }
    }
}
