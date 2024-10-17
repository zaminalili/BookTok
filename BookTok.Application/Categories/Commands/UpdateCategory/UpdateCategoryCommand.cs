using MediatR;

namespace BookTok.Application.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommand: IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public bool IsRemoved { get; set; }
}
