using Microsoft.EntityFrameworkCore;

namespace BalanceCoinAPI.Infrastructure.DAL
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options)
            
            : base(options) { 
        
        
        }
        //public DbSet<Income>  Incomes { get; set; }
        public DbSet<BalanceCoinAPI.Expence> Expences { get; set; }
        public DbSet<BalanceCoinAPI.Transaction> Transactions { get; set; }
        public DbSet<BalanceCoinAPI.Balance> Balances { get; set; }
        public DbSet<BalanceCoinAPI.Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Balance>().HasKey(b => b.Id);
            base.OnModelCreating(modelBuilder);
        }

    }
}
