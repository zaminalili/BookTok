using AutoMapper;
using BookTok.Application.Authors.Dtos;
using BookTok.Application.Common;
using BookTok.Domain.Repositories;
using MediatR;

namespace BookTok.Application.Authors.Queries.GetAllUnverifiedAuthors;

public class GetAllUnverifiedAuthorsQueryHandler(IAuthorRepository authorRepository, IMapper mapper) : IRequestHandler<GetAllUnverifiedAuthorsQuery, PaginationResult<AuthorDto>>
{
    public async Task<PaginationResult<AuthorDto>> Handle(GetAllUnverifiedAuthorsQuery request, CancellationToken cancellationToken)
    {
        var (authors, totalCount) = await authorRepository.GetAllUnverifiedAsync(request.searchPhrase, request.pageSize, request.pageNumber);

        var authorDtos = mapper.Map<IEnumerable<AuthorDto>>(authors);
        var result = new PaginationResult<AuthorDto>(authorDtos, totalCount, request.pageSize, request.pageNumber);
        return result;
    }
}
