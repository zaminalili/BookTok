using Microsoft.AspNetCore.Identity;

namespace BookTok.Domain.Entities;

public class User : IdentityUser
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public ICollection<Quote> Quotes { get; set; }
    public ICollection<Review> Reviews { get; set; }

    public ICollection<UserBook> Books { get; set; }
}
