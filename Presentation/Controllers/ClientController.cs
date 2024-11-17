using Application.Commands.RegisterClient;
using Application.Queries.GetAllClients;
using Application.Queries.GetClientBalance;
using Application.Queries.GetClientTransactions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ClientController : Controller
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var result = await _mediator.Send(new GetAllClientsQuery());
            return Ok(result);
        }

        [HttpGet("ClientTransactions/{clientId}")]
        public async Task<IActionResult> GetClientTransactions(
            Guid clientId, [FromQuery] int pageNumber, [FromQuery] int pageSize, [FromQuery] string sortBy,
            [FromQuery] bool isAscending)
        {
            var result = await _mediator.Send(
                new GetClientTransactionsQuery(clientId, pageNumber, pageSize, sortBy, isAscending));
            return Ok(result);
        }

        [HttpGet("ClientBalance/{clientId}")]
        public async Task<IActionResult> GetClientBalance(Guid clientId, [FromQuery] List<string> currencies)
        {
            var result = await _mediator.Send(new GetClientBalanceQuery(clientId, currencies));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterClient([FromBody] RegisterClientCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
