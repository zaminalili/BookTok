using AutoMapper;
using BookTok.Application.Books.Dtos;
using BookTok.Application.Quotes.Dtos;
using BookTok.Domain.Exceptions;
using BookTok.Domain.Entities;
using BookTok.Domain.Repositories;
using MediatR;

namespace BookTok.Application.Quotes.Queries.GetQuoteById;

public class GetQuoteByIdQueryHandler(IQuoteRepository quoteRepository, IMapper mapper) : IRequestHandler<GetQuoteByIdQuery, QuoteDto>
{
    public async Task<QuoteDto> Handle(GetQuoteByIdQuery request, CancellationToken cancellationToken)
    {
        var quote = await quoteRepository.GetByIdAsync(request.Id)
           ?? throw new NotFoundException(nameof(Quote), request.Id.ToString());

        var quoteDto = mapper.Map<QuoteDto>(quote);

        return quoteDto;
    }
}
