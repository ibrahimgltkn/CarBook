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
    public class GetBlogTitleByMaxCommentQueryHandler : IRequestHandler<GetBlogTitleByMaxCommentQuery, GetBlogTitleByMaxCommentQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetBlogTitleByMaxCommentQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogTitleByMaxCommentQueryResult> Handle(GetBlogTitleByMaxCommentQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetBlogTitleByMaxComment();
            return new GetBlogTitleByMaxCommentQueryResult
            {
                BlogTitleByMaxComment = value
            };
        }
    }
}
