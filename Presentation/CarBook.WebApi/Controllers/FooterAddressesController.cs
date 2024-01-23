using CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult>  FooterAddressesList()
        {
            var values = await _mediator.Send(new GetFooterAddressQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterAddresses(int id)
        {
            var values = await _mediator.Send(new GetFooterAddressByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFooterAddresses(CreateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer bilgisi eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFooterAddresses(int id)
        {
            await _mediator.Send(new RemoveFooterAddressCommand(id));
            return Ok("Footer bilgisi silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFooterAddresses(UpdateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer bilgisi güncellendi.");
        }


    }
}
