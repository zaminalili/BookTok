using AutoMapper;
using BookTok.Domain.Entities;
using BookTok.Domain.Exceptions;
using BookTok.Domain.Repositories;
using MediatR;

namespace BookTok.Application.Books.Commands.UpdateBook;

public class UpdateBookCommandHandler(IBookRepository bookRepository, ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<UpdateBookCommand>
{
    public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetByIdAsync(request.Id);
        var category = await categoryRepository.GetByIdAsync(request.CategoryId);

        if (book == null)
            throw new NotFoundException(nameof(Book), request.Id.ToString());
        if (category == null)
            throw new NotFoundException(nameof(Category), request.CategoryId.ToString());

        mapper.Map(request, book);
        await bookRepository.UpdateAsync(book);
    }
}
