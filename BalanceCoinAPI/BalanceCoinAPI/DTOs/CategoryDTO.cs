using System.Text.Json.Serialization;

namespace BalanceCoinAPI.DTOs
{
    public class CategoryDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }

       public string? Description { get; set; }
        //test


    }
}
