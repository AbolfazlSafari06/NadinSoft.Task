using AutoMapper;
using AutoMapper.Internal;
using NadinSoft.Application.Contract.DTO.Product;
using NadinSoft.Domain.Entities.ProductAgg;
using Xunit;

namespace NadinSoft.Application.Test.Mapper;

public class MapperTest
{
    [Fact]
    public void Mapper_Should_Create_Same_Dto()
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.Internal().MethodMappingEnabled = false;
            mc.AddProfile(new AutoMapperProfile());
        });

        IMapper mapper = new AutoMapper.Mapper(mapperConfig);

        mapper.ConfigurationProvider.AssertConfigurationIsValid();
        const string name = "product 1";
        const string manufacturePhone = "123456789";
        const string manufactureEmail = "test@test.com";
        const bool isAvailable = true;
        var produceDate = DateTime.Now;
        var userId = Guid.NewGuid().ToString();


        var product = new Product(name, manufacturePhone, manufactureEmail, isAvailable, produceDate, userId);
        var productDto = mapper.Map<ProductDto>(product);

        Assert.Equal(productDto.ProduceDate, product.ProduceDate);
        Assert.Equal(productDto.Id, product.Id);
        Assert.Equal(productDto.ManufactureEmail, product.ManufactureEmail);
        Assert.Equal(productDto.IsAvailable, product.IsAvailable);
        Assert.Equal(productDto.ManufacturePhone, product.ManufacturePhone);
        Assert.Equal(productDto.Name, product.Name);
    }
}