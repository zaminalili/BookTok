using AutoMapper;
using BookTok.Domain.Entities;
using BookTok.Domain.Repositories;
using MediatR;

namespace BookTok.Application.Books.Commands.CreateBook;

public class CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper) : IRequestHandler<CreateBookCommand, Guid>
{
    public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = mapper.Map<Book>(request);

        var bookId = await bookRepository.AddAsync(book);
        return bookId;
    }
}
