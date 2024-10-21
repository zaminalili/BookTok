using MediatR;

namespace BookTok.Application.Quotes.Commands.CreateQuote;

public class CreateQuoteCommand: IRequest<Guid>
{
    public string QuoteText { get; set; } = default!;
    public int PageNumber { get; set; }

    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
}
