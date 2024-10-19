using BookTok.Domain.Entities;
using BookTok.Domain.Repositories;
using BookTok.Infrastructure.Persistence;

namespace BookTok.Infrastructure.Repositories;

internal class BookAuthorRepository(BooktokDbContext dbContext): IBookAuthorRepository
{
    public async Task AddAsync(BookAuthor bookAuthor)
    {
        await dbContext.AddAsync(bookAuthor);
        await dbContext.SaveChangesAsync();
    }
}
