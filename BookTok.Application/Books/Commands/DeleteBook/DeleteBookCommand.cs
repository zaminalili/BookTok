using MediatR;

namespace BookTok.Application.Books.Commands.DeleteBook;

public class DeleteBookCommand(Guid id) : IRequest
{
    public Guid Id { get; set; } = id;
}
