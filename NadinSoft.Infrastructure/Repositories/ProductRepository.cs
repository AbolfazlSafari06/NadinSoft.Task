using System.Linq;
using Microsoft.EntityFrameworkCore;
using NadinSoft.Domain.Entities.ProductAgg; 
using NadinSoft.Domain.IRepositories.ProductRepository;
using NadinSoft.Infrastructure.EFContext;

namespace NadinSoft.Infrastructure.Repositories;

public class ProductRepository :  BaseRepository<Guid,Product>, IProductRepository
{
    private readonly NadinSoftContext _context;
    public ProductRepository(NadinSoftContext context) : base(context)
    {
        _context = context;
    } 
    public Task<List<Product>> GetListByUserIdAsync(string UserId)
    {
        return _context.Products.Where(x => x.UserId.Equals(UserId)).AsNoTracking().ToListAsync();
    }
}