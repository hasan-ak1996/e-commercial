using AutoMapper;
using e_commercial_API.Errors;
using e_commercial_Domain;
using e_commercial_Domain.Dtos.ProductDtos;
using e_commercial_Domain.Models;
using e_commercial_Repository.IRepository;
using e_commercial_Repository.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_commercial_API.Controllers
{
    public class ProductController : BaseApiController
    {

        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductController(
            IGenericRepository<Product> productRepo,
            IGenericRepository<ProductBrand> productBrandRepo,
            IGenericRepository<ProductType> productTypeRepo,
            IMapper mapper
            )
        {
            _productRepo = productRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
            _mapper = mapper;
        }

        [HttpGet("GetProducts")]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts()
        {
            var spec = new ProductSpecification();
            var prducts = await _productRepo.GetAllWithSpec(spec);

            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(prducts));
        }
        [HttpGet("GetProduct/{id}")]
        // to display responses types for this end point in swagger
        [ProducesResponseType(StatusCodes.Status200OK)]
        // if response type is 404 not found , response object is ApiResponse
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var spec = new ProductSpecification(id);
            var product = await _productRepo.GetEntityWithSpec(spec);
            if (product == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return _mapper.Map<Product, ProductDto>(product);
        }
        [HttpGet("GetProductBrands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepo.AllListAsync());
        }
        [HttpGet("GetProductTypes")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepo.AllListAsync());
        }

    }
}
