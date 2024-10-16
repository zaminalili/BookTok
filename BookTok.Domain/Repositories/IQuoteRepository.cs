using BookTok.Domain.Entities;

namespace BookTok.Domain.Repositories;

public interface IQuoteRepository
{
    Task<Guid> AddAsync(Quote quote);
    Task<(IEnumerable<Quote>, int)> GetAllAsync(string? searchPhrase, int pageSize, int pageNumber);
    Task<Quote?> GetByIdAsync(Guid id);
    Task DeleteAsync(Quote quote);
    Task UpdateAsync(Quote quote);
}
