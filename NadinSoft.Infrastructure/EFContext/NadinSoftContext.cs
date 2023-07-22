using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NadinSoft.Domain.Entities.ProductAgg;
using NadinSoft.Domain.Entities.UserAgg;
using NadinSoft.Infrastructure.Mapping;

namespace NadinSoft.Infrastructure.EFContext;

public class NadinSoftContext : IdentityDbContext<ApplicationUser>
{
    public NadinSoftContext(DbContextOptions<NadinSoftContext> options) : base(options)
    {
    }
 
    public DbSet<Product> Products { get; set; }
 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductMapping).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}