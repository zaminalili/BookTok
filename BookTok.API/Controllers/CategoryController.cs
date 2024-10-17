using BookTok.Application.Categories.Commands.CreateCategory;
using BookTok.Application.Categories.Commands.UpdateCategory;
using BookTok.Application.Categories.Queries.GetAllCategories;
using BookTok.Application.Categories.Queries.GetAllRemovedCategories;
using BookTok.Application.Categories.Queries.GetCategoryById;
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

        [HttpGet]
        [Route("removed")]
        public async Task<IActionResult> GetAllRemoved()
        {
            var categories = await mediator.Send(new GetAllRemovedCategoriesQuery());
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var categories = await mediator.Send(new GetCategoryByIdQuery(id));
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
        {
            Guid id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateCategoryCommand command)
        {
            command.Id = id;
            await mediator.Send(command);
            return NoContent();
        }
    }
}
