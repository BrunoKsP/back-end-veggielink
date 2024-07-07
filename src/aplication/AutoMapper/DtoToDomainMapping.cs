using aplication.Dtos.Products;
using AutoMapper;
using data.domain.Collections;
using VeggieLink.Aplication.Dtos.Category;
using VeggieLink.Aplication.Dtos.User;
using VeggieLink.Data.Collections;

namespace aplication.AutoMapper;

public class DtoToDomainMapping : Profile
{
    public DtoToDomainMapping()
    {
        CreateMap<CreateProductDto, ProductCollection>();
        CreateMap<CreateUserDto, UserCollection>();
        CreateMap<CreateCategoryDto, CategoryCollection>();
    }
}