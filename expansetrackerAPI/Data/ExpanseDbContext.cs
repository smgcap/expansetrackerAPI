using expansetrackerAPI.Models;
using expansetrackerAPI.Models.Income;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace expansetrackerAPI.Data
{
    public class ExpanseDbContext : DbContext
    {
        public ExpanseDbContext(DbContextOptions<ExpanseDbContext> options) : base(options)
        {

        }
        public DbSet<UserRegistraion> userRegistraions { get; set; }
        public DbSet<SessionRegistration> sessionRegistraions { get; set; }

        #region Income Dbset
        public DbSet<IncomeSource> IncomeSources { get; set; }
        public DbSet<RecurringIncome> RecurringIncomes { get; set; }
        public DbSet<OneTimeIncome> OneTimeIncomes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Frequency> Frequencies { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define relationships
            modelBuilder.Entity<IncomeSource>()
                .HasOne(i => i.Category)
                .WithMany()
                .HasForeignKey(i => i.CategoryID);

            modelBuilder.Entity<IncomeSource>()
                .HasOne(i => i.Frequency)
                .WithMany()
                .HasForeignKey(i => i.FrequencyID);

            modelBuilder.Entity<RecurringIncome>()
                .HasOne(i => i.Category)
                .WithMany()
                .HasForeignKey(i => i.CategoryID);

            modelBuilder.Entity<RecurringIncome>()
                .HasOne(i => i.Frequency)
                .WithMany()
                .HasForeignKey(i => i.FrequencyID);

            modelBuilder.Entity<OneTimeIncome>()
                .HasOne(i => i.Category)
                .WithMany()
                .HasForeignKey(i => i.CategoryID);
        }
    }
}
