using AutoMapper;
using BookTok.Domain.Entities;
using BookTok.Domain.Repositories;
using MediatR;

namespace BookTok.Application.Authors.Commands.CreateAuthor;

public class CreateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper) : IRequestHandler<CreateAuthorCommand, Guid>
{
    public async Task<Guid> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = mapper.Map<Author>(request);

        Guid authorId = await authorRepository.AddAsync(author);
        return authorId;
    }
}
