using BookTok.Domain.Entities;

namespace BookTok.Domain.Repositories;

public interface ICategoryRepository
{
    Task<Guid> AddAsync(Category category);
    Task<IEnumerable<Category>> GetAllAsync();
    Task<IEnumerable<Category>> GetAllRemovedAsync();
    Task<Category?> GetByIdAsync(Guid id);
    Task UpdateAsync(Author author);
}
