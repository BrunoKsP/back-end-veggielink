using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeggieLink.Aplication.Dtos.Category;
using VeggieLink.Aplication.Interfaces;
using VeggieLink.Data.Collections;

namespace VeggieLink.Api.Controllers;

[Route("category")]
public class CategoryController : BaseController
{
    private readonly ICategoryService _service;

    public CategoryController(ICategoryService service)
    {
        _service = service;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateCategoryDto dto)
    {
        await _service.Create(dto);
        return Ok("Criado Com Sucesso");
    }
    [HttpGet]
    public async Task<CategoryCollection> GetCategory([FromQuery] string id)
    {
        return await _service.GetCategory(id);
    }

    [HttpGet("all")]
    public async Task<IList<CategoryCollection>> GetAllCategorys()
    {
        return await _service.GetAllCategorys();
    }
}