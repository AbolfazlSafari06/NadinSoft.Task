using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NadinSoft.Application.Contract.Identity;

namespace NadinSoft.Infrastructure.Mapping;

public class ApplicationRoleMapping : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = StaticUserRoles.USER, NormalizedName = StaticUserRoles.USER.ToUpper() });
    }
} 