using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Commands.WriteOff
{
    public class WriteOffCommandHandler : IRequestHandler<WriteOffCommand, WriteOffCommandResult>
    {
        private readonly ITransactionRepository _transactionRepository;

        public WriteOffCommandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<WriteOffCommandResult> Handle(WriteOffCommand request, CancellationToken cancellationToken)
        {
            var currentBalance = await _transactionRepository.GetClientsCurrentBalanceAsync(request.ClientId);

            if ((currentBalance - request.Amount) < 0)
            {
                throw new InvalidOperationException("Unable to write off funds. There are not enough funds on the balance.");
            }

            var writeOff = new Transaction
            {
                Amount = -(request.Amount),
                TransactionDate = DateTime.UtcNow,
                TransactionComment = request.TransactionComment,
                ClientId = request.ClientId
            };

            await _transactionRepository.CreateTransactionAsync(writeOff);

            return new WriteOffCommandResult
            {
                ResultMessage = "Write off completed successfully."
            };
        }
    }
}
