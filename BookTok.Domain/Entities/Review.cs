namespace BookTok.Domain.Entities;

public class Review
{
    public Guid Id { get; set; }
    public string ReviewText { get; set; } = default!;
    public int Rating { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }

    public User User { get; set; }
    public Book Book { get; set; }
}
