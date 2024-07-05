using aplication.Dtos.Products;
using aplication.Exceptions;
using AutoMapper;
using data.domain.Collections;
using VeggieLink.Aplication.Dtos.Products;
using VeggieLink.Aplication.Validators.ProductValidator;
using VeggieLink.Infra.Interfaces;

namespace aplication.Services;

public class ProductService : BaseService, IProductService
{
    private readonly IProductRepository _repository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository repository, IMapper mapper, ICategoryRepository categoryRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }
    public async Task Create(CreateProductDto dto)
    {
        Validate(new CreateProductValidator(), dto);

        var product = _mapper.Map<ProductCollection>(dto);

        await _repository.Create(product);
    }
    public async Task<Dictionary<string, List<ProductDto>>> GetAllProducts()
    {
        var products = await _repository.GetAllProducts();
        var categoryIds = products.Select(p => p.CategoryId).Distinct().ToList();
        var categoryNames = await _categoryRepository.GetCategoriesById(categoryIds);
        var categoryDictionary = categoryNames.ToDictionary(c => c.Id, c => c.Name);

        var groupedProducts = new Dictionary<string, List<ProductDto>>();

        foreach (var product in products)
        {
            var categoryName = categoryDictionary.ContainsKey(product.CategoryId) ? categoryDictionary[product.CategoryId] : "Categoria Desconhecida";

            if (!groupedProducts.ContainsKey(categoryName))
            {
                groupedProducts[categoryName] = new List<ProductDto>();
            }

            groupedProducts[categoryName].Add(new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Thumb = product.Thumb,
                CategoryId = product.CategoryId,
                CategoryName = categoryName
            });
        }

        return groupedProducts;
    }

    public async Task<ListProductDto> GetProduct(string id)
    {
        var product = await _repository.GetProduct(id) ?? throw CustomException.EntityNotFound(new { error = "Produto não encontrado" });

        return _mapper.Map<ListProductDto>(product);
    }
    public async Task ChangeProduct(ChangeProductDto dto, string id)
    {
        Validate(new ChangeProductValidator(), dto);
        var product = await _repository.GetProduct(id) ?? throw CustomException.EntityNotFound(new { error = "Produto não encontrado" });

        var newproduct = new ProductCollection
        {
            Name = dto.Name,
            Description = dto.Description,
            PlantingDate = dto.PlantingDate,
            PreparingDate = dto.PreparingDate,
            HarverstDate = dto.HarverstDate,
            Status = dto.Status,
            Thumb = dto.Thumb,
            Fertilizer = dto.Fertilizer,
            Observation = dto.Observation,
            CategoryId = dto.CategoryId
        };
        await _repository.UpdateProduct(newproduct, id);
    }
}