using MediatR;

namespace BookTok.Application.BookAuthors.Command;

public class AddBookAuthorCommand(Guid bookId, Guid authorId): IRequest
{
    public Guid BookId { get; set; } = bookId;
    public Guid AuthorId { get; set; } = authorId;
}
