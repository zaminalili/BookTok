using BookTok.Application.Authors.Commands.ChangeAuthorVerification;
using BookTok.Application.Authors.Commands.CreateAuthor;
using BookTok.Application.Authors.Commands.UpdateAuthor;
using BookTok.Application.Authors.Queries.GetAllAuthors;
using BookTok.Application.Authors.Queries.GetAllUnverifiedAuthors;
using BookTok.Application.Authors.Queries.GetAuthorById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookTok.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllAuthorsQuery query)
        {
            var authors = await mediator.Send(query);
            return Ok(authors);
        }

        [HttpGet]
        [Route("unverified")]
        public async Task<IActionResult> GetAllUnverified([FromQuery] GetAllUnverifiedAuthorsQuery query)
        {
            var authors = await mediator.Send(query);
            return Ok(authors);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var author = await mediator.Send(new GetAuthorByIdQuery(id));

            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAuthorCommand command)
        {
            Guid id = await mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateAuthorCommand command)
        {
            command.Id = id;
            await mediator.Send(command);

            return NoContent();
        }

        [HttpPatch]
        [Route("changeVerification/{id}")]
        public async Task<IActionResult> ChangeVerification([FromRoute] Guid id)
        {

            await mediator.Send(new ChangeAuthorVerificationCommand(id));

            return NoContent();
        }
    }
}
