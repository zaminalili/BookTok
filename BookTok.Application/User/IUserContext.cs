namespace BookTok.Application.User;

public interface IUserContext
{
    CurrentUser? GetCurrentUser();
}
