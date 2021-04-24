using API.Core.DbModels;
using API.Core.Interfaces;
using API.Core.Specifications;
using API.Dtos;
using API.Infrastructure.DataContext;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{    
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;
        private readonly IMapper _mapper;
     
        public ProductsController(IGenericRepository<Product> productRepository, 
            IGenericRepository<ProductBrand> productBrandRepository, IGenericRepository<ProductType> productTypeRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductWithProductTypeAndBrandsSpecification();
            var data = await _productRepository.ListAsync(spec);
            //return Ok(data);
            //return data.Select(product => new ProductToReturnDto
            //{
            //    Id = product.Id,
            //    Name = product.Name,
            //    Description = product.Description,
            //    PictureUrl = product.PictureUrl,
            //    Price = product.Price,
            //    ProductBrands = product.ProductBrands != null ? product.ProductBrands.Name : string.Empty,
            //    ProductType = product.ProductType != null ? product.ProductType.Name : string.Empty
            //}).ToList();
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProducts(int id)
        {
            var spec = new ProductWithProductTypeAndBrandsSpecification(id);
            //return await _productRepository.GetEntityWithSpecc(spec);

            var product = await _productRepository.GetEntityWithSpecc(spec);
            //return new ProductToReturnDto
            //{
            //    Id = product.Id,
            //    Name = product.Name,
            //    Description = product.Description,
            //    PictureUrl = product.PictureUrl,
            //    Price = product.Price,
            //    ProductBrands = product.ProductBrands != null ? product.ProductBrands.Name : string.Empty,
            //    ProductType = product.ProductType != null ? product.ProductType.Name : string.Empty
            //};

            return _mapper.Map<Product, ProductToReturnDto>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepository.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepository.ListAllAsync());
        }
    }
}
