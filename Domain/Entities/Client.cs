namespace Domain.Entities
{
    public class Client
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public List<Transaction>? Transactions { get; set; }
    }
}
