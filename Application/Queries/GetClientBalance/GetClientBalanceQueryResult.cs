﻿using Application.Common.Dtos;

namespace Application.Queries.GetClientBalance
{
    public class GetClientsBalanceQueryResult
    {
        public List<ClientBalanceDto>? Balance { get; set; }
    }
}