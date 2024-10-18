using BookTok.Application.Books.Dtos;
using MediatR;

namespace BookTok.Application.Books.Queries.GetBookById;

public class GetBookByIdQuery(Guid id): IRequest<BookDto>
{
    public Guid Id { get; set; } = id;
}
