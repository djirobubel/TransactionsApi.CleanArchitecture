﻿namespace Application.Queries.GetAllClients
{
    public class GetAllClientsDto
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
    }
}