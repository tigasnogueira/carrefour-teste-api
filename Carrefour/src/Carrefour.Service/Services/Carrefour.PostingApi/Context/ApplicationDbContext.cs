using Carrefour.TransactionApi.Model;
using Microsoft.EntityFrameworkCore;

namespace Carrefour.TransactionApi.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }

    public DbSet<TransactionModel>? Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Transaction entity
        modelBuilder.Entity<TransactionModel>()
            .HasKey(t => t.Id);

        modelBuilder.Entity<TransactionModel>()
            .Property(t => t.Amount)
            .IsRequired();

        modelBuilder.Entity<TransactionModel>()
            .Property(t => t.Description)
            .HasMaxLength(255);

        modelBuilder.Entity<TransactionModel>()
            .Property(t => t.Date)
            .IsRequired();

        modelBuilder.Entity<TransactionModel>()
            .HasOne(t => t.Account)
            .WithMany(a => a.Transactions)
            .HasForeignKey(t => t.AccountId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
