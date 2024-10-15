namespace BookTok.Domain.Entities;

public class User
{
    public ICollection<Quote> Quotes { get; set; }
    public ICollection<Review> Reviews { get; set; }

    public ICollection<UserBook> Books { get; set; }
}
