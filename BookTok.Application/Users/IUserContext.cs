namespace BookTok.Application.Users;

public interface IUserContext
{
    CurrentUser? GetCurrentUser();
}
