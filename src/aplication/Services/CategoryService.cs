using aplication.Exceptions;
using AutoMapper;
using VeggieLink.Aplication.Dtos.Category;
using VeggieLink.Aplication.Interfaces;
using VeggieLink.Data.Collections;
using VeggieLink.Infra.Interfaces;

namespace VeggieLink.Aplication.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
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
    public async Task<CategoryCollection> GetCategory(string id)
    {
       return await _repository.GetCategory(id) ?? throw CustomException.EntityNotFound(new { error = "Categoria não encontrada" });
    }
}