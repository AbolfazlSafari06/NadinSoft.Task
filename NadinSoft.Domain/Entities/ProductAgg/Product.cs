using NadinSoft.Domain.Entities.UserAgg;

namespace NadinSoft.Domain.Entities.ProductAgg;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string ManufacturePhone { get; set; }
    public string ManufactureEmail { get; set; }
    public bool IsAvailable { get; set; }
    public DateTime ProduceDate { get; set; }
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
    public Product(string name, string manufacturePhone, string manufactureEmail, bool isAvailable, DateTime produceDate,string userId)
    {
        Name = name;
        ManufacturePhone = manufacturePhone;
        ManufactureEmail = manufactureEmail;
        IsAvailable = isAvailable;
        ProduceDate = produceDate;
        UserId = userId;
    }

    public void SetName(string value)
    {
        Name = value;
    }
    public void SetManufacturePhone(string value)
    {
        ManufacturePhone = value;
    }
    public void SetManufactureEmail(string value)
    {
        ManufactureEmail = value;
    }
    public void SetIsAvailable(bool value)
    {
        IsAvailable = value;
    }
    public void SetProduceDate(DateTime value)
    {
        ProduceDate = value;
    }
}