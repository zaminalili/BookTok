using AutoMapper;
using BookTok.Application.Books.Dtos;
using BookTok.Domain.Exceptions;
using BookTok.Domain.Entities;
using BookTok.Domain.Repositories;
using MediatR;

namespace BookTok.Application.Books.Queries.GetBookById;

public class GetBookByIdHandler(IBookRepository bookRepository, IMapper mapper) : IRequestHandler<GetBookByIdQuery, BookDto>
{
    async Task<BookDto> IRequestHandler<GetBookByIdQuery, BookDto>.Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Book), request.Id.ToString());

        var bookDto = mapper.Map<BookDto>(book);

        return bookDto;
    }
}
