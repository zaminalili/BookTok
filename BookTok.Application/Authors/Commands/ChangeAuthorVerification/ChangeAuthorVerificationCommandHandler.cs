using AutoMapper;
using BookTok.Domain.Repositories;
using MediatR;

namespace BookTok.Application.Authors.Commands.ChangeAuthorVerification;

public class ChangeAuthorVerificationCommandHandler(IAuthorRepository authorRepository) : IRequestHandler<ChangeAuthorVerificationCommand>
{
    public async Task Handle(ChangeAuthorVerificationCommand request, CancellationToken cancellationToken)
    {
        await authorRepository.ChangeVerification(request.Id);
    }
}
