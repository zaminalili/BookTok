using FluentValidation;

namespace BookTok.Application.Books.Queries.GetAllBooks;

public class GetAllBooksQueryValidator: AbstractValidator<GetAllBooksQuery>
{
    private int[] allowPageSizes = [5, 10, 15];
    public GetAllBooksQueryValidator()
    {
        RuleFor(b => b.pageNumber).GreaterThanOrEqualTo(1);

        RuleFor(b => b.pageSize)
            .Must(v => allowPageSizes.Contains(v))
            .WithMessage($"Page size must be in {string.Join(",", allowPageSizes)}");
    }
}
