using System.ComponentModel.DataAnnotations;


namespace BalanceCoinAPI

{
    public class Balance
    {
         [Key]
         public int Id { get; set; }
         public int CurrentBalance { get; set; }
         public int ExpenceAmount { get; set; }
         public int IncomeAmount { get; set; }
        

    }
}
