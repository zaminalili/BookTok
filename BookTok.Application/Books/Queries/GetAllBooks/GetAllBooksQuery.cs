using BookTok.Application.Books.Dtos;
using BookTok.Application.Common;
using MediatR;

namespace BookTok.Application.Books.Queries.GetAllBooks;

public class GetAllBooksQuery: IRequest<PaginationResult<BookDto>>
{
    public string? searchPhrase { get; set; }
    public int pageSize { get; set; } = 10;
    public int pageNumber { get; set; } = 1;
}
