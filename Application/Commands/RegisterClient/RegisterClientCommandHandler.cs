using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Commands.RegisterClient
{
    public class RegisterClientCommandHandler : IRequestHandler<RegisterClientCommand, RegisterClientCommandResult>
    {
        private readonly IClientRepository _clientRepository;

        public RegisterClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<RegisterClientCommandResult> Handle(RegisterClientCommand request, CancellationToken cancellationToken)
        {
            var client = new Client
            {
                FirstName = request.FirstName,
                SecondName = request.SecondName
            };

            await _clientRepository.RegisterClientAsync(client);

            return new RegisterClientCommandResult
            {
                ResultMessage = "Successfully registered."
            };
        }
    }
}
