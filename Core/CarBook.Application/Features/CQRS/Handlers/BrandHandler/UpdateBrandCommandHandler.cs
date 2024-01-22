﻿using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandler
{
	public class UpdateBrandCommandHandler
	{
		private readonly IRepository<Brand> _repository;

		public UpdateBrandCommandHandler(IRepository<Brand> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateBrandCommand command)
		{
			var value = await _repository.GetByIdAsync(command.BrandID);
			value.Name = command.Name;
			await _repository.UpdateAsync(value);
		}
	}
}
