using BookTok.Domain.Entities;

namespace BookTok.Domain.Repositories;

public interface IReviewRepository
{
    Task<Guid> AddAsync(Review review);
    Task<(IEnumerable<Review>, int)> GetAllAsync(string? searchPhrase, int pageSize, int pageNumber);
    Task<Review?> GetByIdAsync(Guid id);
    Task DeleteAsync(Review review);
    Task UpdateAsync(Review review);
}
