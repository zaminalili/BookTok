using BookTok.Domain.Entities;

namespace BookTok.Domain.Repositories;

public interface IBookAuthorRepository
{
    Task AddAsync(BookAuthor bookAuthor);
}
