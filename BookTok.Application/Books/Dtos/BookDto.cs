using BookTok.Domain.Entities;

namespace BookTok.Application.Books.Dtos;

public class BookDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int PageCount { get; set; }
    public int AverageRating { get; set; }
    public int RatingsCount { get; set; }
    public Guid CategoryId { get; set; }
    public ICollection<Author> Authors { get; set; }

    public ICollection<Quote> Quotes { get; set; }
    public ICollection<Review> Reviews { get; set; }
    public ICollection<UserBook> Users { get; set; }
}
