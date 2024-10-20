namespace BookTok.Domain.Entities;

public class Quote
{
    public Guid Id { get; set; }
    public string QuoteText { get; set; } = default!;
    public int PageNumber { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;

    public string UserId { get; set; } = Guid.NewGuid().ToString();
    public Guid BookId { get; set; }

    public User User { get; set; }
    public Book Book { get; set; }

}
