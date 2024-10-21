using FluentValidation;

namespace BookTok.Application.Quotes.Commands.UpdateQuote;

public class UpdateQuoteCommandValidator: AbstractValidator<UpdateQuoteCommand>
{
    public UpdateQuoteCommandValidator()
    {
        RuleFor(c => c.QuoteText)
            .NotEmpty()
            .NotEmpty()
            .MaximumLength(500);

        RuleFor(c => c.PageNumber).GreaterThanOrEqualTo(1);
    }
}
