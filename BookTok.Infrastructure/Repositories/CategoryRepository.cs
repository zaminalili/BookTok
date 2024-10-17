using BookTok.Domain.Entities;
using BookTok.Domain.Repositories;
using BookTok.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookTok.Infrastructure.Repositories;

internal class CategoryRepository(BooktokDbContext dbContext): ICategoryRepository
{
    public async Task<Guid> AddAsync(Category category)
    {
        await dbContext.Categories.AddAsync(category);
        await dbContext.SaveChangesAsync();
        return category.Id;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        var categories = await dbContext.Categories
            .Include(c => c.Books)
            .Where(c => c.IsRemoved == false)
            .ToListAsync();

        return categories;
    }

    public async Task<IEnumerable<Category>> GetAllRemovedAsync()
    {
        var categories = await dbContext.Categories
            .Include(c => c.Books)
            .Where(c => c.IsRemoved == true)
            .ToListAsync();

        return categories;
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await dbContext.Categories.Include(c => c.Books).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(Category category)
    {
        dbContext.Categories.Update(category);
        await dbContext.SaveChangesAsync();
    }
}
