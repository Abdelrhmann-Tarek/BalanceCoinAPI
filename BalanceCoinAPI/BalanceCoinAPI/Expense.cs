using System.ComponentModel.DataAnnotations;

namespace BalanceCoinAPI
{
    public class Expense
    {
        
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Amount { get; set; }
        public int CategoryId {  get; set; } //Foreign
        public DateTime Date { get; set; }
        public Category Category { get; set; } = null!; 



        // Add other properties based on your design
    }
}

