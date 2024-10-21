using BookTok.Application.Common;
using BookTok.Application.Quotes.Dtos;
using MediatR;

namespace BookTok.Application.Quotes.Queries.GetAllQuotes;

public class GetAllQuotesQuery : IRequest<PaginationResult<QuoteDto>>
{
    public string? searchPhrase { get; set; }
    public int pageSize { get; set; } = 10;
    public int pageNumber { get; set; } = 1;
}
