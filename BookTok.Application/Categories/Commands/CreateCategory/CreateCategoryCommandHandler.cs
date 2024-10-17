using AutoMapper;
using BookTok.Domain.Entities;
using BookTok.Domain.Repositories;
using MediatR;

namespace BookTok.Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<CreateCategoryCommand, Guid>
{
    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = mapper.Map<Category>(request);

        Guid categoryId = await categoryRepository.AddAsync(category);
        return categoryId;
    }
}
