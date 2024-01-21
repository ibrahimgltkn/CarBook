﻿using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandler
{
	public class UpdateBannerCommandHandler
	{
		private readonly IRepository<Banner> _repository;

		public UpdateBannerCommandHandler(IRepository<Banner> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateBannerCommand command)
		{
			var values = await _repository.GetByIdAsync(command.BannerId);
			values.Description = command.Description;
			values.Title = command.Title;
			values.VideoDescription = command.VideoDescription;
			values.VideoUrl = command.VideoUrl;
			await _repository.UpdateAsync(values);
		}
	}
}
