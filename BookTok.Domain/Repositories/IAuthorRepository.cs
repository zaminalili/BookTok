using BookTok.Domain.Entities;

namespace BookTok.Domain.Repositories;

public interface IAuthorRepository
{
    Task<Guid> AddAsync(Author author);
    Task<(IEnumerable<Author>, int)> GetAllAsync(string? searchPhrase, int pageSize, int pageNumber);
    Task<(IEnumerable<Author>, int)> GetAllUnverifiedAsync(string? searchPhrase, int pageSize, int pageNumber);
    Task<Author?> GetByIdAsync(Guid id);
    Task DeleteAsync(Author author);
    Task UpdateAsync(Author author);
    Task ChangeVerification(Guid id);
    Task SaveChangesAsync();
}
