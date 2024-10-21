using MediatR;

namespace BookTok.Application.Quotes.Commands.DeleteQuote;

public class DeleteQuoteCommand(Guid id): IRequest
{
    public Guid Id { get; set; } = id;
}
