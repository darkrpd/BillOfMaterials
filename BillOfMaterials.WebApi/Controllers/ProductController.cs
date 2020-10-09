using AutoMapper;
using BillOfMaterials.Core.Models;
using BillOfMaterials.Core.Services;
using BillOfMaterials.WebApi.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks; 

namespace BillOfMaterials.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        private readonly ICategoryService _categoryService;

        private readonly IMapper _mapper;
        public ProductController(IProductService productService, ICategoryService categoryService , IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products =  _productService.GetAll();
             
            var productResources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);

            return Ok(productResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetCategoryByParentId(int id)
        {
            var categories = await _categoryService.GetByParentId(id);

            var categoryResources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(categories);

            return Ok(categoryResources);
        }

    }
}
