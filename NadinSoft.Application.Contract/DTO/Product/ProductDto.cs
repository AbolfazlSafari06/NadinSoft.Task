using NadinSoft.Application.Contract.Extension;

namespace NadinSoft.Application.Contract.DTO.Product;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ManufacturePhone { get; set; }
    public string ManufactureEmail { get; set; }
    public bool IsAvailable { get; set; }
    public DateTime ProduceDate { get; set; }
    public string ProduceDateToPersian { get; set; }
}