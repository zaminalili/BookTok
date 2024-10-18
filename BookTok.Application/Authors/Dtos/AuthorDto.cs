namespace BookTok.Application.Authors.Dtos;

public class AuthorDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = default!;
    public bool HasAccount { get; set; } = false;
    public string? AccountUsername { get; set; }
}
