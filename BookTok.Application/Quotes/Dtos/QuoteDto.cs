using BookTok.Domain.Entities;

namespace BookTok.Application.Quotes.Dtos;

public class QuoteDto
{
    public Guid Id { get; set; }
    public string QuoteText { get; set; } = default!;
    public int PageNumber { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;

    //public Guid UserId { get; set; }
    //public Guid BookId { get; set; }

    public User User { get; set; }
    public Book Book { get; set; }
}
