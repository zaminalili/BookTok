namespace BookTok.Domain.Entities;

public class UserBook
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
    public DateTime DateRead { get; set; } = DateTime.Now;

    public User User { get; set; }
    public Book Book { get; set; }
}
