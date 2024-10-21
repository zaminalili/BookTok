using MediatR;

namespace BookTok.Application.Quotes.Commands.UpdateQuote;

public class UpdateQuoteCommand: IRequest
{
    public Guid Id { get; set; }
    public string QuoteText { get; set; } = default!;
    public int PageNumber { get; set; }

    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
}
