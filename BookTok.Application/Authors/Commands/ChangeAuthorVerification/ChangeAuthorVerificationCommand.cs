using MediatR;

namespace BookTok.Application.Authors.Commands.ChangeAuthorVerification;

public class ChangeAuthorVerificationCommand(Guid id): IRequest
{
    public Guid Id { get; set; } = id;
}
