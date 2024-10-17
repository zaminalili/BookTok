﻿using FluentValidation;

namespace BookTok.Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommandValidator: AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotNull()
            .NotEmpty().WithMessage("Category name cannot be empty")
            .MaximumLength(20).WithMessage("Category name can have a maximum length of 20")
            .MinimumLength(3).WithMessage("Category name can have a minimum length of 3");



    }
}