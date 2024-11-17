using MediatR;

namespace Application.Commands.WriteOff
{
    public class WriteOffCommand : IRequest<WriteOffCommandResult>
    {
        public Guid ClientId { get; set; }
        public decimal Amount { get; set; }
        public string? TransactionComment { get; set; }
    }
}
