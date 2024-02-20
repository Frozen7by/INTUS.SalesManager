using INTUS.SalesManager.Domain.Models.Common;
using INTUS.SalesManager.Domain.Models.Lookups;
using INTUS.SalesManager.Domain.Models.Orders;
using INTUS.SalesManager.Domain.Models.SubElements;
using INTUS.SalesManager.Domain.Models.Windows;
using INTUS.SalesManager.Infrastructure.DataAccess.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace INTUS.SalesManager.Infrastructure.DataAccess;

public class SalesManagerDbContext(DbContextOptions<SalesManagerDbContext> options) : DbContext(options)
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Window> Windows { get; set; }
    public DbSet<SubElement> SubElements { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<ElementType> ElementTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.AddInterceptors(new EntityChangesInterceptor());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Order>()
            .HasQueryFilter(it => it.DeletedDate == null);
        modelBuilder.Entity<SubElement>()
            .HasQueryFilter(it => it.DeletedDate == null);
        modelBuilder.Entity<Window>()
            .HasQueryFilter(it => it.DeletedDate == null);
    }
}
