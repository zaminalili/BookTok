using BookTok.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookTok.Infrastructure.Persistence;

internal class BooktokDbContext(DbContextOptions<BooktokDbContext> options): DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Quote> Quotes { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<UserBook>().HasKey(ub => new { ub.UserId, ub.BookId});

        builder.Entity<UserBook>()
            .HasOne(ub => ub.User)
            .WithMany(ub => ub.Books)
            .HasForeignKey(ub => ub.UserId);

        builder.Entity<UserBook>()
            .HasOne(ub => ub.Book)
            .WithMany(ub => ub.Users)
            .HasForeignKey(ub => ub.BookId);
    }
}
