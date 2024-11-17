using Application.Ports.Transactions;
using Domain.Entities;
using MediatR;

namespace Application.Commands.Accrual
{
    public class AccrualCommandHandler : IRequestHandler<AccrualCommand, AccrualCommandResult>
    {
        private readonly ITransactionRepository _transactionRepository;

        public AccrualCommandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<AccrualCommandResult> Handle(AccrualCommand request, CancellationToken cancellationToken)
        {
            var accrual = new Transaction
            {
                Amount = request.Amount,
                TransactionDate = DateTime.UtcNow,
                TransactionComment = request.TransactionComment,
                ClientId = request.ClientId
            };

            await _transactionRepository.CreateTransactionAsync(accrual);

            return new AccrualCommandResult
            {
                ResultMessage = "Accrual completed successfully."
            };
        }
    }
}
