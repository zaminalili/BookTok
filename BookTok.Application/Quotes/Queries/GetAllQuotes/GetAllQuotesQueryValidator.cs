using FluentValidation;

namespace BookTok.Application.Quotes.Queries.GetAllQuotes;

public class GetAllQuotesQueryValidator: AbstractValidator<GetAllQuotesQuery>
{
    private int[] allowPageSizes = [5, 10, 15];
    public GetAllQuotesQueryValidator()
    {
        RuleFor(b => b.pageNumber).GreaterThanOrEqualTo(1);

        RuleFor(b => b.pageSize)
            .Must(v => allowPageSizes.Contains(v))
            .WithMessage($"Page size must be in {string.Join(",", allowPageSizes)}");
    }
}
