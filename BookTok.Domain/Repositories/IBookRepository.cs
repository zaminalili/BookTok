using BookTok.Domain.Entities;

namespace BookTok.Domain.Repositories;

public interface IBookRepository
{
    Task<Guid> AddAsync(Book book);
    Task<(IEnumerable<Book>, int)> GetAllAsync(string? searchPhrase, int pageSize, int pageNumber);
    Task<Book?> GetByIdAsync(Guid id);
    Task DeleteAsync(Book book);
    Task UpdateAsync(Book book);
    Task SaveChangesAsync();
}
