using BookTok.Application.Categories.Dtos;
using MediatR;

namespace BookTok.Application.Categories.Queries.GetAllRemovedCategories;

public class GetAllRemovedCategoriesQuery: IRequest<IEnumerable<CategoryDto>>
{
}
