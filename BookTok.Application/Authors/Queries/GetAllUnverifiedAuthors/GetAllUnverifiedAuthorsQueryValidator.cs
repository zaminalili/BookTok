using FluentValidation;

namespace BookTok.Application.Authors.Queries.GetAllUnverifiedAuthors;

public class GetAllUnverifiedAuthorsQueryValidator: AbstractValidator<GetAllUnverifiedAuthorsQuery>
{
    private int[] allowPageSizes = [5, 10, 15];
    public GetAllUnverifiedAuthorsQueryValidator()
    {
        RuleFor(r => r.pageNumber).GreaterThanOrEqualTo(1);

        RuleFor(r => r.pageSize)
            .Must(v => allowPageSizes.Contains(v))
            .WithMessage($"Page size must be in {string.Join(",", allowPageSizes)}");
    }
}
