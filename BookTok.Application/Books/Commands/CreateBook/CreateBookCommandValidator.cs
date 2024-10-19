using FluentValidation;

namespace BookTok.Application.Books.Commands.CreateBook;

public class CreateBookCommandValidator: AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {

        RuleFor(c => c.Title)
            .NotEmpty()
            .NotNull()
            .MaximumLength(20)
            .MinimumLength(2);

        RuleFor(c => c.Description)
            .NotEmpty()
            .NotNull()
            .MaximumLength(300);

        RuleFor(c => c.PageCount)
            .GreaterThanOrEqualTo(1);

        RuleFor(c => c.RatingsCount)
            .GreaterThanOrEqualTo(0);

        RuleFor(c => c.AverageRating)
            .GreaterThanOrEqualTo(1);
    }
}
