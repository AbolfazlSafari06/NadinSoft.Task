using NadinSoft.Domain.Entities.ProductAgg;
using Xunit;

namespace NadinSoft.Domain.Test;

public class ProductTests
{
    [Fact]
    public void Product_Constructor_Should_Construct_Course_Properly()
    {
        const string name = "product 1";
        const string manufacturePhone = "123456789";
        const string manufactureEmail = "test@test.com";
        const bool isAvailable = true;
        var produceDate = DateTime.Now;


        var product = new Product(name, manufacturePhone, manufactureEmail, isAvailable, produceDate);

        Assert.Equal(name, product.Name);
        Assert.Equal(produceDate, product.ProduceDate);
        Assert.Equal(manufactureEmail, product.ManufactureEmail);
        Assert.Equal(manufacturePhone, product.ManufacturePhone);
        Assert.Equal(isAvailable, product.IsAvailable);
    }
}