using BookTok.Application.Books.Queries.GetAllBooks;
using BookTok.Application.Books.Queries.GetBookById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookTok.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllBooksQuery query)
        {
            var books = await mediator.Send(query);
            return Ok(books);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var book = await mediator.Send(new GetBookByIdQuery(id));
            return Ok(book);
        }
    }
}
