namespace BookTok.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public ICollection<Quote> Quotes { get; set; }
    public ICollection<Review> Reviews { get; set; }

    public ICollection<UserBook> Books { get; set; }
}
