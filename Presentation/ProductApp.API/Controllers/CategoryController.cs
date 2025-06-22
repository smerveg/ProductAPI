using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Application.Features.Queries.Category.GetAllCategory;

namespace ProductApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result=await _mediator.Send(new GetAllCategoryQueryRequest());

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
    }
}
