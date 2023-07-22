using System.ComponentModel.DataAnnotations;

namespace NadinSoft.Application.Contract.DTO.Product;

public class CreateProductDto
{
    [Required, MaxLength(256, ErrorMessage = nameof(Name))]
    public string Name { get; set; }

    [Required, MaxLength(256, ErrorMessage = nameof(ManufacturePhone))]
    public string ManufacturePhone { get; set; }

    [Required, MaxLength(256, ErrorMessage = nameof(ManufactureEmail)), DataType(DataType.EmailAddress)]
    public string ManufactureEmail { get; set; }

    [Required(ErrorMessage = nameof(IsAvailable))]
    public bool IsAvailable { get; set; }

    [Required(ErrorMessage = nameof(ProduceDate))]
    public DateTime ProduceDate { get; set; } 
}