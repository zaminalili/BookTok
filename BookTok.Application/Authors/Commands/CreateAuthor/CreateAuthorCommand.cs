using MediatR;

namespace BookTok.Application.Authors.Commands.CreateAuthor;

public class CreateAuthorCommand: IRequest<Guid>
{
    public string FullName { get; set; } = default!;
    public bool HasAccount { get; set; } = false;
    public string? AccountUsername { get; set; }
}
