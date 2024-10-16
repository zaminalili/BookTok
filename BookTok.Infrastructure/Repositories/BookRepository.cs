using BookTok.Domain.Entities;
using BookTok.Domain.Repositories;
using BookTok.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookTok.Infrastructure.Repositories;

internal class BookRepository(BooktokDbContext dbContext): IBookRepository
{
    public async Task<Guid> AddAsync(Book book)
    {
        await dbContext.Books.AddAsync(book);
        await dbContext.SaveChangesAsync();
        return book.Id;
    }

    public async Task<(IEnumerable<Book>, int)> GetAllAsync(string? searchPhrase, int pageSize, int pageNumber)
    {
        var searchPhraseLower = searchPhrase?.ToLower();

        var baseQuery = GetBooksWithIncludes()
            .Where(b => searchPhraseLower == null || b.Title.ToLower().Contains(searchPhraseLower));

        int totalCount = baseQuery.Count();

        var books = await baseQuery
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToListAsync();

        return (books, totalCount);
    }

    public async Task<Book?> GetByIdAsync(Guid id)
    {
        return await GetBooksWithIncludes().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task DeleteAsync(Book book)
    {
        dbContext.Books.Remove(book);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Book book)
    {
        dbContext.Update(book);
        await dbContext.SaveChangesAsync();
    }

    public async Task SaveChangesAsync() => await dbContext.SaveChangesAsync();

    private IQueryable<Book> GetBooksWithIncludes()
    {
        return dbContext.Books
            .Include(b => b.Authors)
            .Include(b => b.Quotes)
            .Include(b => b.Reviews)
            .Include(b => b.Users);
    }
}
