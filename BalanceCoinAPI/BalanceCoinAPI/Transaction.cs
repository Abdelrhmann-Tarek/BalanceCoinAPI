namespace BalanceCoinAPI
{
    public class Transaction
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Amount { get; set; }
        public int CategoryId { get; set; }
        public DateTime? Date { get; set; }

        public string? Type { get; set; }
        
    }
}
