using NadinSoft.Application.Contract.DTO.Product;

namespace NadinSoft.Application.Contract.IApplication.ProductApplication;

public interface IProductApplication
{
    Task<List<ProductDto>> GetListAsync(string? userId);
    Task<ProductDto> CreateAsync(string userId,CreateProductDto command);
    Task<ProductDto> UpdateAsync(string userId, UpdateProductDto command);
    Task RemoveAsync(string userId, Guid id);
    Task<ProductDto> GetByIdAsync(string userId, Guid id);
}