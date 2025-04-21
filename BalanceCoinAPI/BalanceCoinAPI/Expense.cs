using System.ComponentModel.DataAnnotations;

namespace BalanceCoinAPI
{
    public class Expense
    {
        
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Amount { get; set; }
        public int CategoryId {  get; set; }
        public DateTime Date { get; set; }



        // Add other properties based on your design
    }
}

