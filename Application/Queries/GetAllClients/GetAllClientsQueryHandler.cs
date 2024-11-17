using Application.Ports.Clients;
using MediatR;

namespace Application.Queries.GetAllClients
{
    public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, GetAllClientsQueryResult>
    {
        private readonly IClientRepository _clientRepository;

        public GetAllClientsQueryHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<GetAllClientsQueryResult> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var clients = await _clientRepository.GetAllClientsAsync();

            var clientsDto = clients.Select(x => new GetAllClientsDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                SecondName = x.SecondName
            }).ToList();

            return new GetAllClientsQueryResult
            {
                Clients = clientsDto
            };
        }
    }
}
