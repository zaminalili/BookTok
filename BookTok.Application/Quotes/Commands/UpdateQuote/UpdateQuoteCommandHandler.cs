using AutoMapper;
using BookTok.Domain.Exceptions;
using BookTok.Domain.Entities;
using BookTok.Domain.Repositories;
using MediatR;

namespace BookTok.Application.Quotes.Commands.UpdateQuote;

public class UpdateQuoteCommandHandler(IQuoteRepository quoteRepository, IBookRepository bookRepository, IMapper mapper) : IRequestHandler<UpdateQuoteCommand>
{
    public async Task Handle(UpdateQuoteCommand request, CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetByIdAsync(request.BookId);
        var quote = await quoteRepository.GetByIdAsync(request.Id);

        if (book == null)
            throw new NotFoundException(nameof(Book), request.BookId.ToString());
        if (quote == null)
            throw new NotFoundException(nameof(Quote), request.Id.ToString());

        mapper.Map(request, quote);

        await quoteRepository.UpdateAsync(quote);
    }
}
