using FluentValidation;

namespace BookTok.Application.Authors.Commands.UpdateAuthor;

public class UpdateAuthorCommandValidator: AbstractValidator<UpdateAuthorCommand>
{
    public UpdateAuthorCommandValidator()
    {
        RuleFor(a => a.FullName)
            .NotNull()
            .NotEmpty().WithMessage("Author name cannot be empty")
            .MaximumLength(30).WithMessage("Author name can have a maximum length of 30")
            .MinimumLength(3).WithMessage("Category name can have a minimum length of 3");

        
    }
}
