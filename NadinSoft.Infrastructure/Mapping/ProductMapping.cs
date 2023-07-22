using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NadinSoft.Domain.Entities.ProductAgg;

namespace NadinSoft.Infrastructure.Mapping;
 
public class ProductMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.ProduceDate).IsRequired();
        builder.Property(x => x.IsAvailable).IsRequired();
        builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
        builder.Property(x => x.ManufactureEmail).IsRequired().HasMaxLength(255);
        builder.Property(x => x.ManufacturePhone).IsRequired().HasMaxLength(255);

        builder.HasOne(x => x.User).WithMany(x => x.Products).HasForeignKey(x => x.UserId);
    }
}