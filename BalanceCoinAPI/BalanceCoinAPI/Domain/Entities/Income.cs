namespace BalanceCoinAPI.Domain.Entities
{
    public class Income
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Amount { get; set; }
        public int CategoryId { get; set; } //Foreign Key
        public DateTime Date { get; set; }
        public Category Category { get; set; } = null!; // ask chatgpt 1254
        //dd


    }
}
