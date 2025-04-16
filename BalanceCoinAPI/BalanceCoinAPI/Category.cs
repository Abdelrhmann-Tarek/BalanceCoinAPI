using System.ComponentModel.DataAnnotations;

namespace BalanceCoinAPI
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        // Add other properties based on your design
    }
}
