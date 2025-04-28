using System.Text.Json.Serialization;

namespace BalanceCoinAPI.DTOs
{
    public class IncomeDTO
    {
        [JsonIgnore] // hide the Id property in Swagger
        public int Id { get; set; }
        public string Title { get; set; }
        public int Amount { get; set; }
        public int CategoryId { get; set; }
        public DateTime Date { get; set; }

    }
}
