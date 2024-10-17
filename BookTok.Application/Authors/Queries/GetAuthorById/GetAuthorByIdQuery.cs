using BookTok.Application.Authors.Dtos;
using MediatR;

namespace BookTok.Application.Authors.Queries.GetAuthorById;

public class GetAuthorByIdQuery(Guid id): IRequest<AuthorDto>
{
    public Guid Id { get; set; } = id;
}
