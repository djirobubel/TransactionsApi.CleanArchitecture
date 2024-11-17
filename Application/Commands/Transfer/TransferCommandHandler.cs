using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Commands.Transfer
{
    public class TransferCommandHandler : IRequestHandler<TransferCommand, TransferCommandResult>
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransferCommandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<TransferCommandResult> Handle(TransferCommand request, CancellationToken cancellationToken)
        {
            var senderBalance = await _transactionRepository.GetClientsCurrentBalanceAsync(request.SenderId);

            if ((senderBalance - request.TransferSum) < 0)
            {
                throw new InvalidOperationException(
                    "Unable to transfer funds. There are not enough funds on the sender balance.");
            }

            var writeOff = new Transaction
            {
                Amount = -(request.TransferSum),
                ClientId = request.SenderId,
                TransactionComment = request.TransferComment,
                TransactionDate = DateTime.UtcNow,
            };

            await _transactionRepository.CreateTransactionAsync(writeOff);

            var accrual = new Transaction
            {
                Amount = request.TransferSum,
                ClientId = request.RecieverId,
                TransactionComment = request.TransferComment,
                TransactionDate = DateTime.UtcNow
            };

            await _transactionRepository.CreateTransactionAsync(accrual);

            return new TransferCommandResult
            {
                ResultMessage = "Transfer completed succesfully."
            };
        }
    }
}
