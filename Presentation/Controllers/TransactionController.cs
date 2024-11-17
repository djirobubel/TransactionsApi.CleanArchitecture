using Application.Commands.Accrual;
using Application.Commands.Transfer;
using Application.Commands.WriteOff;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TransactionController : Controller
    {
        private readonly IMediator _mediator;

        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Accrual")]
        public async Task<IActionResult> Accrual([FromBody] AccrualCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("WriteOff")]
        public async Task<IActionResult> WriteOff([FromBody] WriteOffCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("Transfer")]
        public async Task<IActionResult> Transfer([FromBody] TransferCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
