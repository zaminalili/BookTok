
using FluentValidation;

namespace BookTok.Application.Quotes.Commands.CreateQuote;

public class CreateQuoteCommandValidator: AbstractValidator<CreateQuoteCommand>
{
    public CreateQuoteCommandValidator()
    {
        RuleFor(c => c.QuoteText)
            .NotEmpty()
            .NotEmpty()
            .MaximumLength(500);
       
        RuleFor(c => c.PageNumber).GreaterThanOrEqualTo(1);

    }
}
