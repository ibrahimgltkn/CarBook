using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandler
{
	public class GetBrandQueryHandler
	{
		private readonly IRepository<Brand> _repository;

		public GetBrandQueryHandler(IRepository<Brand> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetBrandByIdQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetBrandByIdQueryResult
			{
				BrandID = x.BrandID,
				Name = x.Name
			}).ToList();
		}
	}
}
