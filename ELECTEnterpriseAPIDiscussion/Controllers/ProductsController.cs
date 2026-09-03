using ELECTEnterpriseAPIDiscussion.Models;
using Microsoft.AspNetCore.Mvc;
using ELECTEnterpriseAPIDiscussion.Common;
using ELECTEnterpriseAPIDiscussion.DTOs;

namespace ELECTEnterpriseAPIDiscussion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        //public static readonly List<Product> _products = new()
        //{
        //    new Product { Id = 1, Name = "Product 1", Price = 10.00m },
        //    new Product { Id = 2, Name = "Product 2", Price = 20.00m },
        //    new Product { Id = 3, Name = "Product 3", Price = 30.00m }
        //};



        [HttpGet]
        public IActionResult GetAll() => Ok(ApiResponse<List<Product>>.SuccessResponse(_products));

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound(ApiResponse<object?>.FailResponse("Product Not Found"));

            return Ok(ApiResponse<Product>.SuccessResponse(product));
        }

        [HttpPost]
        public IActionResult Create([FromBody]CreateProductDto dto)
        {
            if(!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(e => e.Errors).Select(x => x.ErrorMessage).ToList();
                return BadRequest(ApiResponse<object?>.FailResponse("Validation Failed", errors));
            }


            //TODO: Standardize by using the service design pattern
            var product = new Product
            {
                Id = _products.Max(p => p.Id) + 1,
                Name = dto.Name,
                Price = dto.Price,
                Description = dto.Description,
                Sku = dto.Sku,
                StockQuantity = dto.StockQuantity,
                CategoryId = dto.CategoryId,
                IsActive = true,
                Tags = dto.Tags,
                Created = DateTime.Now
            };
            _products.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, ApiResponse<Product>.SuccessResponse(product));
        }
    }
}
