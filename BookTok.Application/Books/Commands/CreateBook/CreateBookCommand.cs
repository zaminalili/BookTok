using MediatR;

namespace BookTok.Application.Books.Commands.CreateBook;

public class CreateBookCommand: IRequest<Guid>
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int PageCount { get; set; }
    public int AverageRating { get; set; }
    public int RatingsCount { get; set; }
    public Guid CategoryId { get; set; }
}
