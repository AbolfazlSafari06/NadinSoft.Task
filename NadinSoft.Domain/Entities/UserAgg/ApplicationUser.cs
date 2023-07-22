using Microsoft.AspNetCore.Identity;
using NadinSoft.Domain.Entities.ProductAgg;

namespace NadinSoft.Domain.Entities.UserAgg;
public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Product> Products { get; set; } 
}