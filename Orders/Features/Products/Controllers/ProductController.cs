using System;
using Microsoft.AspNetCore.Mvc;
using Orders.Application.Features.Products.Handlers;
using Orders.Domain.Products;
using Orders.Features.Products.Requests;
using Orders.Features.Products.Responses;

namespace Orders.Features.Products.Controllers
{
    [Route("api/products")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(typeof(ProductResponse), 200)]
        public IActionResult Get([FromQuery(Name = "uid")] string productUid)
        {
            try
            {
                var request = new GetProductRequest(productUid);
                var product = _mediator.SendRequest<IGetProductRequest, IProductDto>(request);
                return Ok(new ProductResponse(product));
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductResponse), 200)]
        public IActionResult Create([FromBody] CreateProductRequest createProductRequest)
        {
            try
            {
                var product = _mediator.SendRequest<ICreateProductRequest, IProductDto>(createProductRequest);
                return Ok(new ProductResponse(product));
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }
    }
}