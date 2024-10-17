﻿using MediatR;

namespace BookTok.Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommand: IRequest<Guid>
{
    public string Name { get; set; } = default!;
}
