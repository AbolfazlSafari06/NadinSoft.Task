using NadinSoft.Domain.Entities.ProductAgg;

namespace NadinSoft.Domain.IRepositories.ProductRepository;
public interface IProductRepository : IBaseRepository<Guid, Product>
{
    Task<List<Product>> GetListByUserIdAsync(string UserId);
}