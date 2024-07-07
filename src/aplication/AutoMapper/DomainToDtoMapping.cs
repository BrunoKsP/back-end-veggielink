using aplication.Dtos.Products;
using AutoMapper;
using data.domain.Collections;
using Microsoft.Extensions.Configuration;
using VeggieLink.Aplication.Dtos.Category;
using VeggieLink.Aplication.Dtos.Products;
using VeggieLink.Data.Collections;

namespace aplication.AutoMapper;

public class DomainToDtoMapping : Profile
{
    public DomainToDtoMapping(IConfiguration config)
    {
        CreateMap<ProductCollection, ProductDto>();
        CreateMap<ProductCollection, ListProductDto>();
        CreateMap<CategoryCollection, CategoryDto>();
    }
}