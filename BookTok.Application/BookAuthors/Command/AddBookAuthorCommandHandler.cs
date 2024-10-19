using BookTok.Domain.Exceptions;
using BookTok.Domain.Entities;
using BookTok.Domain.Repositories;
using MediatR;
using AutoMapper;

namespace BookTok.Application.BookAuthors.Command;

public class AddBookAuthorCommandHandler(IBookAuthorRepository bookAuthorRepository, IBookRepository bookRepository, IAuthorRepository authorRepository, IMapper mapper) : IRequestHandler<AddBookAuthorCommand>
{
    public async Task Handle(AddBookAuthorCommand request, CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetByIdAsync(request.BookId);
        var author = await authorRepository.GetByIdAsync(request.AuthorId);

        if (book == null)
            throw new NotFoundException(nameof(Book), request.BookId.ToString());

        if (author == null)
            throw new NotFoundException(nameof(Author), request.AuthorId.ToString());

        var bookAuthor = mapper.Map<BookAuthor>(request);

        await bookAuthorRepository.AddAsync(bookAuthor);
    }
}
