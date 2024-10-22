using AutoMapper;
using BookTok.Application.User;
using BookTok.Domain.Entities;
using BookTok.Domain.Exceptions;
using BookTok.Domain.Repositories;
using MediatR;

namespace BookTok.Application.Quotes.Commands.CreateQuote;

public class CreateQuoteCommandHandler(
    IQuoteRepository quoteRepository, 
    IBookRepository bookRepository, 
    IMapper mapper, 
    IUserContext userContext) : IRequestHandler<CreateQuoteCommand, Guid>
{
    public async Task<Guid> Handle(CreateQuoteCommand request, CancellationToken cancellationToken)
    {
       var book = await bookRepository.GetByIdAsync(request.BookId);

        if (book == null)
            throw new NotFoundException(nameof(Book), request.BookId.ToString());

        var currentUser = userContext.GetCurrentUser();

        var quote = mapper.Map<Quote>(request);
        quote.UserId = currentUser.Id;

        var quoteId = await quoteRepository.AddAsync(quote);
        return quoteId;
    }
}
