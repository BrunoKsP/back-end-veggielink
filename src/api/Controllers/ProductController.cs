using aplication.Dtos.Products;
using data.domain.Collections;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeggieLink.Aplication.Dtos.Products;
using VeggieLink.Aplication.Interfaces;

namespace VeggieLink.Api.Controllers
{
    [Route("products")]
    public class ProductController : BaseController
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto dto)
        {
            await _service.Create(dto);
            return Ok("Criado Com Sucesso");
        }
        [HttpGet("all")]
        public async Task<Dictionary<string, List<ProductDto>>> GetAllProducts()
        {
            return await _service.GetAllProducts();

        }
        [HttpGet]
        public async Task<ProductCollection> GetProduct([FromQuery] string id)
        {
            return await _service.GetProduct(id);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> ChangeProduct([FromBody] ChangeProductDto dto, [FromQuery] string id)
        {
            await _service.ChangeProduct(dto, id);
            return Ok("Alterado Com Sucesso");
        }
    }
}