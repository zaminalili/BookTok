using AutoMapper;
using BookTok.Application.Categories.Dtos;
using BookTok.Domain.Repositories;
using MediatR;

namespace BookTok.Application.Categories.Queries.GetAllRemovedCategories;

public class GetAllRemovedCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<GetAllRemovedCategoriesQuery, IEnumerable<CategoryDto>>
{
    public async Task<IEnumerable<CategoryDto>> Handle(GetAllRemovedCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await categoryRepository.GetAllRemovedAsync();
        var categoryDtos = mapper.Map<IEnumerable<CategoryDto>>(categories);

        return categoryDtos;
    }
}
