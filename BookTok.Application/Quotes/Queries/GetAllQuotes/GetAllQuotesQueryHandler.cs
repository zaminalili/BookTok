using AutoMapper;
using BookTok.Application.Books.Dtos;
using BookTok.Application.Common;
using BookTok.Application.Quotes.Dtos;
using BookTok.Domain.Repositories;
using MediatR;

namespace BookTok.Application.Quotes.Queries.GetAllQuotes;

public class GetAllQuotesQueryHandler(IQuoteRepository quoteRepository, IMapper mapper) : IRequestHandler<GetAllQuotesQuery, PaginationResult<QuoteDto>>
{
    public async Task<PaginationResult<QuoteDto>> Handle(GetAllQuotesQuery request, CancellationToken cancellationToken)
    {
        var (quotes, totalCount) = await quoteRepository.GetAllAsync(request.searchPhrase, request.pageNumber, request.pageSize);

        var quoteDtos = mapper.Map<IEnumerable<QuoteDto>>(quotes);
        var result = new PaginationResult<QuoteDto>(quoteDtos, totalCount, request.pageSize, request.pageNumber);

        return result;
    }
}
