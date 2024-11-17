using Application.Common.Dtos;

namespace Application.Queries.GetAllClients
{
    public class GetAllClientsQueryResult
    {
        public List<GetAllClientsDto>? Clients { get; set; }
    }
}
