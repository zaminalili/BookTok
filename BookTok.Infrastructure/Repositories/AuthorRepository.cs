using BookTok.Domain.Entities;
using BookTok.Domain.Repositories;
using BookTok.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookTok.Infrastructure.Repositories;

internal class AuthorRepository(BooktokDbContext dbContext): IAuthorRepository
{
    public async Task<Guid> AddAsync(Author author)
    {
        await dbContext.Authors.AddAsync(author);
        await dbContext.SaveChangesAsync();
        return author.Id;
    }

    public async Task<(IEnumerable<Author>, int)> GetAllAsync(string? searchPhrase, int pageSize, int pageNumber)
    {
 
        return await Get(searchPhrase, pageSize, pageNumber, true);
    }

    public async Task<(IEnumerable<Author>, int)> GetAllUnverifiedAsync(string? searchPhrase, int pageSize, int pageNumber)
    {
     
        return await Get(searchPhrase, pageSize, pageNumber, false);
    }


    public async Task ChangeVerification(Guid id)
    {
        var author = await dbContext.Authors.FirstOrDefaultAsync(x => x.Id == id);
        if (author != null) 
            author.IsVerified = !author.IsVerified;

        await dbContext.SaveChangesAsync();
    }
    public async Task<Author?> GetByIdAsync(Guid id)
    {
        return await dbContext.Authors.Include(a => a.Books).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task DeleteAsync(Author author)
    {
        dbContext.Authors.Remove(author);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Author author)
    {
        dbContext.Update(author);
        await dbContext.SaveChangesAsync();
    }

    public async Task SaveChangesAsync() => await dbContext.SaveChangesAsync();

    private async Task<(IEnumerable<Author>, int)> Get(string? searchPhrase, int pageSize, int pageNumber, bool isVerified)
    {
        var searchPhraseLower = searchPhrase?.ToLower();

        var baseQuery = dbContext.Authors
            .Include(a => a.Books)
            .Where(a => (string.IsNullOrEmpty(searchPhraseLower) 
                        || a.FullName.ToLower().Contains(searchPhraseLower))
                        && a.IsVerified == isVerified);

        int totalCount = baseQuery.Count();
        var authors = await baseQuery
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToListAsync();

        return (authors, totalCount);
    }
}
