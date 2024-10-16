using BookTok.Domain.Entities;
using BookTok.Domain.Repositories;
using BookTok.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookTok.Infrastructure.Repositories;

internal class QuoteRepository(BooktokDbContext dbContext): IQuoteRepository
{
    public async Task<Guid> AddAsync(Quote quote)
    {
        await dbContext.Quotes.AddAsync(quote);
        await dbContext.SaveChangesAsync();
        return quote.Id;
    }

    public async Task<(IEnumerable<Quote>, int)> GetAllAsync(string? searchPhrase, int pageSize, int pageNumber)
    {
        var searchPhraseLower = searchPhrase?.ToLower();

        var baseQuery = GetQuotesWithIncludes()
            .Where(q => searchPhraseLower == null || q.QuoteText.ToLower().Contains(searchPhraseLower));

        int totalCount = baseQuery.Count();

        var quotes = await baseQuery
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToListAsync();

        return (quotes, totalCount);
    }

    public async Task<Quote?> GetByIdAsync(Guid id)
    {
        return await GetQuotesWithIncludes().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task DeleteAsync(Quote quote)
    {
        dbContext.Quotes.Remove(quote);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Quote quote)
    {
        dbContext.Update(quote);
        await dbContext.SaveChangesAsync();
    }

    private IQueryable<Quote> GetQuotesWithIncludes()
    {
        return dbContext.Quotes
            .Include(q => q.Book)
            .Include(q => q.User);
    }
}
