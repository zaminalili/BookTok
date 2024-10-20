namespace BookTok.Domain.Entities;

public class UserBook
{
    public Guid Id { get; set; }
    public string UserId { get; set; } = Guid.NewGuid().ToString();
    public Guid BookId { get; set; }
    public DateTime DateRead { get; set; } = DateTime.Now;

    public User User { get; set; }
    public Book Book { get; set; }
}
