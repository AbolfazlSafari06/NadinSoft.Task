using AutoMapper;
using NadinSoft.Application.Contract.DTO.Product;
using NadinSoft.Application.Contract.Exceptions.Product;
using NadinSoft.Application.Contract.Extension;
using NadinSoft.Application.Contract.IApplication.ProductApplication;
using NadinSoft.Domain.Entities.ProductAgg; 
using NadinSoft.Domain.IRepositories.ProductRepository;

namespace NadinSoft.Application;

public class ProductApplication : IProductApplication
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public ProductApplication(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<List<ProductDto>> GetListAsync(string? userId)
    {
        List<Product> products;
        if (!userId.IsNullOrEmpty())
        {
            products = await _productRepository.GetListByUserIdAsync(userId);
        }
        else
        {
            products = await _productRepository.GetListAsync();
        }
        var result = _mapper.Map<List<ProductDto>>(products);
        return result;
    }

    public async Task<ProductDto> CreateAsync(string userId, CreateProductDto command)
    {
        var isDuplicated = await _productRepository.AnyAsync(x => x.ManufactureEmail.Equals(command.ManufactureEmail) && x.ProduceDate.Equals(command.ProduceDate));

        if (isDuplicated)
        {
            throw new DuplicatedProductException();
        }

        var newProduct = new Product(command.Name, command.ManufacturePhone, command.ManufactureEmail, command.IsAvailable,
            command.ProduceDate, userId);

        var product = await _productRepository.CreateAsync(newProduct);


        var result = _mapper.Map<ProductDto>(product);
        return result;
    }

    public async Task<ProductDto> UpdateAsync(string userId, UpdateProductDto command)
    {
        var product = await _productRepository.GetByIdAsync(command.Id);

        if (product is null)
        {
            throw new NotFoundProductException();
        }

        if (!product.UserId.Equals(userId))
        {
            throw new ProductAccessDeniedException();
        }

        if (!command.ManufactureEmail.IsNullOrEmpty()) product.SetManufactureEmail(command.ManufactureEmail);
        if (!command.ManufacturePhone.IsNullOrEmpty()) product.SetManufacturePhone(command.ManufacturePhone);
        if (!command.Name.IsNullOrEmpty()) product.SetName(command.Name);
        product.SetIsAvailable(command.IsAvailable);
        product.SetProduceDate(command.ProduceDate);

        await _productRepository.SaveChangesAsync();

        var result = _mapper.Map<ProductDto>(product);
        return result;
    }

    public async Task RemoveAsync(string userId, Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product is null)
        {
            throw new NotFoundProductException();
        }

        if (!product.UserId.Equals(userId))
        {
            throw new ProductAccessDeniedException();
        }
        await _productRepository.RemoveByIdAsync(product);
    }

    public async Task<ProductDto> GetByIdAsync(string userId, Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product is null)
        {
            throw new NotFoundProductException();
        } 

        var result = _mapper.Map<ProductDto>(product);
        return result;
    }
}