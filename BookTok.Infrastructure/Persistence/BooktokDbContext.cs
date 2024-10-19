using BookTok.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BookTok.Infrastructure.Persistence;

internal class BooktokDbContext(DbContextOptions<BooktokDbContext> options): DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Quote> Quotes { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }

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

        builder.Entity<BookAuthor>()
            .HasKey(ba => new { ba.BookId, ba.AuthorId });

        builder.Entity<BookAuthor>()
            .HasOne(ba => ba.Book)
            .WithMany(b => b.BookAuthors)
            .HasForeignKey(ba => ba.BookId);

        builder.Entity<BookAuthor>()
            .HasOne(ba => ba.Author)
            .WithMany(a => a.BookAuthors)
            .HasForeignKey(ba => ba.AuthorId);
    }
}
