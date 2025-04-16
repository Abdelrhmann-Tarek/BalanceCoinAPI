using Microsoft.EntityFrameworkCore;

namespace BalanceCoinAPI.Infrastructure.DAL
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options)
            
            : base(options) {}
        //public DbSet<Income>  Incomes { get; set; }
        public DbSet<BalanceCoinAPI.Expence> Expences { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Food" },
                new Category { Id = 2, Name = "Transport" },
                new Category { Id = 3, Name = "Salary" }
            );
        }


    }
}
