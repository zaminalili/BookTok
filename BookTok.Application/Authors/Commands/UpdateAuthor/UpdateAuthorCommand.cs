using MediatR;

namespace BookTok.Application.Authors.Commands.UpdateAuthor;

public class UpdateAuthorCommand: IRequest
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = default!;
    public bool HasAccount { get; set; } = false;
    public string? AccountUsername { get; set; }
    public bool IsVerified { get; set; } = false;
}
