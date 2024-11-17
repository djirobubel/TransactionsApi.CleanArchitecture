using MediatR;

namespace Application.Commands.RegisterClient
{
    public class RegisterClientCommand : IRequest<RegisterClientCommandResult>
    {
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
    }
}
