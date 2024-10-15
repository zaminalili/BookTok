namespace BookTok.Domain.Entities;

public class Author
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = default!;
    public bool HasAccount { get; set; } = false;
    public string? AccountUsername { get; set; }
    public bool IsVerified { get; set; } = false;

    public ICollection<Book> Books { get; set; }
}
