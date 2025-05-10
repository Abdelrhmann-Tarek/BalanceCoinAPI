using System.ComponentModel.DataAnnotations;

namespace BalanceCoinAPI.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }

        // Add other properties based on your design
    }
}
