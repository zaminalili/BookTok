using AutoMapper;
using BookTok.Application.Authors.Dtos;
using BookTok.Application.Books.Dtos;
using BookTok.Application.Common;
using BookTok.Domain.Repositories;
using MediatR;

namespace BookTok.Application.Books.Queries.GetAllBooks;

public class GetAllBooksQueryHandler(IBookRepository bookRepository, IMapper mapper) : IRequestHandler<GetAllBooksQuery, PaginationResult<BookDto>>
{
    async Task<PaginationResult<BookDto>> IRequestHandler<GetAllBooksQuery, PaginationResult<BookDto>>.Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var (books, totalCount) = await bookRepository.GetAllAsync(request.searchPhrase, request.pageSize, request.pageNumber);

        var bookDtos = mapper.Map<IEnumerable<BookDto>>(books);
        var result = new PaginationResult<BookDto>(bookDtos, totalCount, request.pageSize, request.pageNumber);
        
        return result;
    }
}
