using BookTok.Application.Categories.Dtos;
using BookTok.Application.Common;
using MediatR;

namespace BookTok.Application.Categories.Queries.GetAllCategories;

public class GetAllCategoriesQuery: IRequest<IEnumerable<CategoryDto>>
{

}
