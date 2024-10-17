using BookTok.Application.Categories.Queries.GetAllCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookTok.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await mediator.Send(new GetAllCategoriesQuery());
            return Ok(categories);
        }
    }
}
