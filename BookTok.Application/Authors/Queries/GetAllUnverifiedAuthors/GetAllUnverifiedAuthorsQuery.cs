using BookTok.Application.Authors.Dtos;
using BookTok.Application.Common;
using MediatR;

namespace BookTok.Application.Authors.Queries.GetAllUnverifiedAuthors;

public class GetAllUnverifiedAuthorsQuery: IRequest<PaginationResult<AuthorDto>>
{
    public string? searchPhrase { get; set; }
    public int pageSize { get; set; } = 10;
    public int pageNumber { get; set; } = 1;
}
