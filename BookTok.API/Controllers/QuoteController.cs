using BookTok.Application.Quotes.Commands.CreateQuote;
using BookTok.Application.Quotes.Commands.DeleteQuote;
using BookTok.Application.Quotes.Commands.UpdateQuote;
using BookTok.Application.Quotes.Queries.GetAllQuotes;
using BookTok.Application.Quotes.Queries.GetQuoteById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookTok.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllQuotesQuery query)
        {
            var quotes = await mediator.Send(query);
            return Ok(quotes);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var quote = await mediator.Send(new GetQuoteByIdQuery(id));
            return Ok(quote);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateQuoteCommand command)
        {
            var quoteId = await mediator.Send(command);
            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] UpdateQuoteCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteQuoteCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }
    }
}
