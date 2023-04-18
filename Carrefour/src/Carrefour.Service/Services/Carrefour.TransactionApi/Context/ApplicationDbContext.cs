using Carrefour.TransactionApi.Model;
using Microsoft.EntityFrameworkCore;

namespace Carrefour.TransactionApi.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }

    public DbSet<TransactionModel> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
            property.SetColumnType("varchar(100)");


        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        // Configure Transaction entity
        modelBuilder.Entity<TransactionModel>()
            .HasKey(t => t.Id);

        modelBuilder.Entity<TransactionModel>()
            .Property(t => t.Amount)
            .IsRequired()
            .HasColumnType("decimal(18,2)"); ;

        modelBuilder.Entity<TransactionModel>()
            .Property(t => t.Description)
            .HasMaxLength(255);

        modelBuilder.Entity<TransactionModel>()
            .Property(t => t.Date)
            .IsRequired();

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("RegisterDate") != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("RegisterDate").CurrentValue = DateTime.Now;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("RegisterDate").IsModified = false;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
