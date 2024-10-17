using AutoMapper;
using BookTok.Domain.Entities;
using BookTok.Domain.Exceptions;
using BookTok.Domain.Repositories;
using MediatR;

namespace BookTok.Application.Categories.Commands.UpdateCategory;

internal class UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<UpdateCategoryCommand>
{
    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.GetByIdAsync(request.Id);
        if (category == null)
            throw new NotFoundException(nameof(Category), request.Id.ToString());

        mapper.Map(request, category);
        await categoryRepository.UpdateAsync(category);
    }
}
