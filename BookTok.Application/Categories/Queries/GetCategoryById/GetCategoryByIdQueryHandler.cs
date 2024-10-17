using AutoMapper;
using BookTok.Application.Categories.Dtos;
using BookTok.Domain.Entities;
using BookTok.Domain.Exceptions;
using BookTok.Domain.Repositories;
using MediatR;

namespace BookTok.Application.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Category), request.Id.ToString());
        
        var categoryDto = mapper.Map<CategoryDto>(category);
        return categoryDto;
    }
}
