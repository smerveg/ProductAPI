using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Application.Features.Commands.Product.AddProduct;
using ProductApp.Application.Features.Commands.Product.DeleteProduct;
using ProductApp.Application.Features.Commands.Product.UpdateProduct;
using ProductApp.Application.Features.Queries.Product.GetAllProduct;
using ProductApp.Application.Features.Queries.Product.GetProductById;
using ProductApp.Application.Features.Queries.Product.GetProductsByCategoryId;
using System.Net;

namespace ProductApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;    
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result=await _mediator.Send(new GetAllProductQueryRequest());

            if(result!=null)
            {
                return Ok(result);
            }

            return NotFound();
            
        }

        [HttpGet("/api/ProductList/{CategoryId}")]
        public async Task<IActionResult> GetProductsByCategoryId([FromRoute]GetProductsByCategoryIdQueryRequest getProductsByCategoryIdQueryRequest)
        {
            var result=await _mediator.Send(getProductsByCategoryIdQueryRequest);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetProductByIdQueryRequest getProductByIdQueryRequest)
        {
            var result = await _mediator.Send(getProductByIdQueryRequest);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductCommandRequest addProductCommandRequest)
        {
            await _mediator.Send(addProductCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommandRequest updateProductCommandRequest)
        {
            await _mediator.Send(updateProductCommandRequest);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute]DeleteProductCommandRequest deleteProductCommandRequest)
        {
            await _mediator.Send(deleteProductCommandRequest);
            return Ok();
        }
    }
}
