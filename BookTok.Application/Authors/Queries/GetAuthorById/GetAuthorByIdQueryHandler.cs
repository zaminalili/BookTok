using AutoMapper;
using BookTok.Application.Authors.Dtos;
using BookTok.Domain.Repositories;
using MediatR;

namespace BookTok.Application.Authors.Queries.GetAuthorById;

public class GetAuthorByIdQueryHandler(IAuthorRepository authorRepository, IMapper mapper) : IRequestHandler<GetAuthorByIdQuery, AuthorDto>
{
    public async Task<AuthorDto> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        var author = await authorRepository.GetByIdAsync(request.Id);
        var authorDto = mapper.Map<AuthorDto>(author);

        return authorDto;
    }
}
