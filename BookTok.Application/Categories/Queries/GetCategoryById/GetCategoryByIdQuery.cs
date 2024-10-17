using BookTok.Application.Categories.Dtos;
using MediatR;

namespace BookTok.Application.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQuery(Guid id): IRequest<CategoryDto>
{
    public Guid Id { get; set; } = id;
}
