using AutoMapper;
using NadinSoft.Application.Contract.DTO.Product;
using NadinSoft.Application.Contract.Extension;
using NadinSoft.Domain.Entities.ProductAgg;

namespace NadinSoft.Application;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Product, ProductDto>().ForMember(x => x.ProduceDateToPersian, x => x.MapFrom(y => y.ProduceDate.ToPersianDate(false)));
    }
}