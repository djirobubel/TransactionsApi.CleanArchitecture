using MediatR;

namespace Application.Commands.Transfer
{
    public class TransferCommand : IRequest<TransferCommandResult>
    {
        public Guid SenderId { get; set; }
        public Guid RecieverId { get; set; }
        public decimal TransferSum { get; set; }
        public string? TransferComment { get; set; }
    }
}
