using BookTok.Domain.Entities;

namespace BookTok.Application.Categories.Dtos;

public class CategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public bool IsRemoved { get; set; } = false;

    public ICollection<Book> Books { get; set; }
}
