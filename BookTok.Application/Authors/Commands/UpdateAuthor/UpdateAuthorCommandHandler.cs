using AutoMapper;
using BookTok.Domain.Entities;
using BookTok.Domain.Exceptions;
using BookTok.Domain.Repositories;
using MediatR;

namespace BookTok.Application.Authors.Commands.UpdateAuthor;

public class UpdateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper) : IRequestHandler<UpdateAuthorCommand>
{
    public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await authorRepository.GetByIdAsync(request.Id);

        if (author == null)
            throw new NotFoundException(nameof(Author), request.Id.ToString());

        mapper.Map(request, author);
        await authorRepository.SaveChangesAsync();
    }
}
