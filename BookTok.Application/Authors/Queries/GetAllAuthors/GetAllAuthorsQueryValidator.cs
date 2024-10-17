using FluentValidation;

namespace BookTok.Application.Authors.Queries.GetAllAuthors;

public class GetAllAuthorsQueryValidator: AbstractValidator<GetAllAuthorsQuery>
{
    private int[] allowPageSizes = [5, 10, 15];
    public GetAllAuthorsQueryValidator()
    {
        RuleFor(r => r.pageNumber).GreaterThanOrEqualTo(1);

        RuleFor(r => r.pageSize)
            .Must(v => allowPageSizes.Contains(v))
            .WithMessage($"Page size must be in {string.Join(",", allowPageSizes)}");
    }
}
