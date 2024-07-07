using aplication.Exceptions;
using AutoMapper;
using VeggieLink.Aplication.Dtos.Category;
using VeggieLink.Aplication.Dtos.Products;
using VeggieLink.Aplication.Interfaces;
using VeggieLink.Data.Collections;
using VeggieLink.Infra.Interfaces;

namespace VeggieLink.Aplication.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;
    private readonly IProductRepository _productsRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository repository, IMapper mapper, IProductRepository productsRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _productsRepository = productsRepository;
    }

    public async Task Create(CreateCategoryDto dto)
    {
        var category = _mapper.Map<CategoryCollection>(dto);

        await _repository.Create(category);
    }
    public async Task<IList<CategoryCollection>> GetAllCategorys()
    {
        return await _repository.GetAllCategorys();
    }
    public async Task<CategoryDto> GetCategory(string id)
    {
        var category = await _repository.GetCategory(id)
             ?? throw CustomException.EntityNotFound(new { error = "Categoria não encontrada" });

        var products = await _productsRepository.GetProductCategory(id);
        var categoryDto = _mapper.Map<CategoryDto>(category);
        categoryDto.Products = _mapper.Map<ICollection<ProductDto>>(products);

        return categoryDto;
    }
}