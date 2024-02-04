using CarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using CarBook.Application.Features.Mediator.Results.TagCloudResults;
using CarBook.Application.Interfaces.TagCloudInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handleres.TagCloudHandlers
{
    public class GetTagCloudByBlogIdQueryHandler : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
    {
        private readonly ITagCloudRepository _repository;

        public GetTagCloudByBlogIdQueryHandler(ITagCloudRepository repository)
        {
            _repository = repository;
        }

        public  async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values =  _repository.GetTagCloudsByBlodId(request.Id);
            return values.Select( x =>new GetTagCloudByBlogIdQueryResult
            {
                Title = x.Title,
                TagCloudID = x.TagCloudID,
                BlogID = x.BlogID
            }).ToList();

        }
    }
}
