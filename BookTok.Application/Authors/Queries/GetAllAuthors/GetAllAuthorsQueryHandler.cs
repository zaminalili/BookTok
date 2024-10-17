using AutoMapper;
using BookTok.Application.Authors.Dtos;
using BookTok.Application.Common;
using BookTok.Domain.Repositories;
using MediatR;

namespace BookTok.Application.Authors.Queries.GetAllAuthors;

public class GetAllAuthorsQueryHandler(IAuthorRepository authorRepository, IMapper mapper) : IRequestHandler<GetAllAuthorsQuery, PaginationResult<AuthorDto>>
{
    public async Task<PaginationResult<AuthorDto>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
    {
        var (authors, totalCount) = await authorRepository.GetAllAsync(request.searchPhrase, request.pageSize, request.pageNumber);

        var authorDtos = mapper.Map<IEnumerable<AuthorDto>>(authors);
        var result = new PaginationResult<AuthorDto>(authorDtos, totalCount, request.pageSize, request.pageNumber);
        return result;
    }
}
