using BalanceCoinAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BalanceCoinAPI.Infrastructure.DAL
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options)
            
            : base(options) {}
        public DbSet<Income>  Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Food" },
                new Category { Id = 2, Name = "Transport" },
                new Category { Id = 3, Name = "Salary" }
            );
             modelBuilder.Entity<Income>()
              .HasOne(i => i.Category)
               .WithMany()
                .HasForeignKey(i => i.CategoryId); // CategoryId has ForeignKey with Category.Id 

                //tst


        }


    }
}
