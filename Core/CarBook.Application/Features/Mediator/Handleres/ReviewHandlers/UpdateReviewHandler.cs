using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handleres.ReviewHandlers
{
    public class UpdateReviewHandler : IRequestHandler<UpdateReviewCommand>
    {
        private readonly IRepository<Review> _repository;
        public UpdateReviewHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.ReviewID);
            values.CustomerName = request.CustomerName;
            values.ReviewDate = request.ReviewDate;
            values.CarID = request.CarID;
            values.Comment = request.Comment;
            values.RaytingValue = request.RaytingValue;
            await _repository.UpdateAsync(values);
        }
    }
}
