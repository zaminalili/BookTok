using BookTok.Domain.Entities;
using BookTok.Domain.Repositories;
using BookTok.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookTok.Infrastructure.Repositories;

internal class ReviewRepository(BooktokDbContext dbContext): IReviewRepository
{
    public async Task<Guid> AddAsync(Review review)
    {
        await dbContext.Reviews.AddAsync(review);
        await dbContext.SaveChangesAsync();
        return review.Id;
    }

    public async Task<(IEnumerable<Review>, int)> GetAllAsync(string? searchPhrase, int pageSize, int pageNumber)
    {
        var searchPhraseLower = searchPhrase?.ToLower();

        var baseQuery = GetQuotesWithIncludes()
            .Where(r => searchPhraseLower == null || r.ReviewText.ToLower().Contains(searchPhraseLower));

        int totalCount = baseQuery.Count();

        var reviews = await baseQuery
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToListAsync();

        return (reviews, totalCount);
    }

    public async Task<Review?> GetByIdAsync(Guid id)
    {
        return await GetQuotesWithIncludes().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task DeleteAsync(Review review)
    {
        dbContext.Reviews.Remove(review);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Review review)
    {
        dbContext.Update(review);
        await dbContext.SaveChangesAsync();
    }

    private IQueryable<Review> GetQuotesWithIncludes()
    {
        return dbContext.Reviews
            .Include(q => q.Book)
            .Include(q => q.User);
    }
}
