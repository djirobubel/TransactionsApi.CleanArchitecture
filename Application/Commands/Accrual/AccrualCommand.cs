using MediatR;

namespace Application.Commands.Accrual
{
    public class AccrualCommand : IRequest<AccrualCommandResult>
    {
        public Guid ClientId { get; set; }
        public decimal Amount { get; set; }
        public string? TransactionComment { get; set; }
    }
}
