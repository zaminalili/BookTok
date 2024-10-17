using AutoMapper;
using BookTok.Application.Categories.Dtos;
using BookTok.Domain.Repositories;
using MediatR;

namespace BookTok.Application.Categories.Queries.GetAllCategories;

public class GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>>
{
    public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await categoryRepository.GetAllAsync();
        var categoryDtos = mapper.Map<IEnumerable<CategoryDto>>(categories);

        return categoryDtos;
    }
}
