using BookTok.Domain.Exceptions;
using BookTok.Domain.Entities;
using BookTok.Domain.Repositories;
using MediatR;
using BookTok.Application.User;

namespace BookTok.Application.Quotes.Commands.DeleteQuote;

public class DeleteQuoteCommandHandler(IQuoteRepository quoteRepository, IUserContext userContext) : IRequestHandler<DeleteQuoteCommand>
{
    public async Task Handle(DeleteQuoteCommand request, CancellationToken cancellationToken)
    {
       var quote = await quoteRepository.GetByIdAsync(request.Id);
       var currentUser = userContext.GetCurrentUser();

        if (quote == null)
            throw new NotFoundException(nameof(Quote), request.Id.ToString());
        if (quote.UserId != currentUser.Id)
            throw new UserMismatchException();

        await quoteRepository.DeleteAsync(quote);
    }
}
