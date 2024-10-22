using BookTok.Application.BookAuthors.Command;
using BookTok.Application.Books.Commands.CreateBook;
using BookTok.Application.Books.Commands.DeleteBook;
using BookTok.Application.Books.Commands.UpdateBook;
using BookTok.Application.Books.Queries.GetAllBooks;
using BookTok.Application.Books.Queries.GetBookById;
using BookTok.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookTok.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRoles.Author)]
    public class BookController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll([FromQuery] GetAllBooksQuery query)
        {
            var books = await mediator.Send(query);
            return Ok(books);
        }

        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var book = await mediator.Send(new GetBookByIdQuery(id));
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookCommand command)
        {
            Guid bookId = await mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { bookId }, null);
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] UpdateBookCommand command)
        {
            await mediator.Send(command);

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await mediator.Send(new DeleteBookCommand(id));
            return NoContent();
        }

        [HttpPost]
        [Route("{bookId}/authors/{authorId}")]
        public async Task<IActionResult> AddAuthorToBook([FromRoute] Guid bookId, [FromRoute] Guid authorId)
        {
            await mediator.Send(new AddBookAuthorCommand(bookId, authorId));
            return NoContent();
        }
    }
}
