namespace BookTok.Domain.Entities;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public bool IsRemoved { get; set; } = false;

    public ICollection<Book> Books { get; set; }
}
