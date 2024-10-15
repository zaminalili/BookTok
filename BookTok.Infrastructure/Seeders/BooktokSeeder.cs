using BookTok.Domain.Entities;
using BookTok.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookTok.Infrastructure.Seeders;

internal class BooktokSeeder(BooktokDbContext dbContext): IBooktokSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Categories.Any())
            {
                var categories = GetCategories();
                dbContext.Categories.AddRange(categories);
                await dbContext.SaveChangesAsync();
            }
        }

    }

    private ICollection<Category> GetCategories()
    {
        List<Category> categories = 
            [ 
            new() { Name = "Science Fiction" },
            new() { Name = "Historical Fiction" },
            new() { Name = "Fantasy" },
            new() { Name = "Mystery" },
            new() { Name = "Thriller" },
            new() { Name = "Romance" },
            new() { Name = "Horror" },
            new() { Name = "Biography" },
            new() { Name = "Autobiography" },
            new() { Name = "Memoir" },
            new() { Name = "Self-help" },
            new() { Name = "Health & Fitness" },
            new() { Name = "History" },
            new() { Name = "Science & Technology" },
            new() { Name = "Business & Economics" },
            new() { Name = "Philosophy" },
            new() { Name = "Religion & Spirituality" },
            new() { Name = "Picture Books" },
            new() { Name = "Early Readers" },
            new() { Name = "Middle Grade" },
            new() { Name = "Young Adult" },
            new() { Name = "Classical Poetry" },
            new() { Name = "Modern Poetry" },
            new() { Name = "Superhero" },
            new() { Name = "Manga" },
            new() { Name = "Fantasy" },
            new() { Name = "Sci-Fi" },
            new() { Name = "Textbook" },
            new() { Name = "Reference" },
            new() { Name = "Study Guides" },
            new() { Name = "Adventure" },
            new() { Name = "Guidebooks" },
            new() { Name = "Recipes" },
            new() { Name = "Culinary History" },

            ];

        return categories;
    }
}
