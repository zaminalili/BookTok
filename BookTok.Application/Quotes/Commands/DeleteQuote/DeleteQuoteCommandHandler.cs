using BookTok.Domain.Exceptions;
using BookTok.Domain.Entities;
using BookTok.Domain.Repositories;
using MediatR;

namespace BookTok.Application.Quotes.Commands.DeleteQuote;

public class DeleteQuoteCommandHandler(IQuoteRepository quoteRepository) : IRequestHandler<DeleteQuoteCommand>
{
    public async Task Handle(DeleteQuoteCommand request, CancellationToken cancellationToken)
    {
       var quote = await quoteRepository.GetByIdAsync(request.Id);
       
        if (quote == null)
            throw new NotFoundException(nameof(Quote), request.Id.ToString());

        await quoteRepository.DeleteAsync(quote);
    }
}
