using BookTok.Application.Quotes.Dtos;
using MediatR;

namespace BookTok.Application.Quotes.Queries.GetQuoteById;

public class GetQuoteByIdQuery(Guid id): IRequest<QuoteDto>
{
    public Guid Id { get; set; } = id;
}
