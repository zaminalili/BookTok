namespace BookTok.Domain.Exceptions;

public class UserMismatchException(): Exception("The user does not match the current user")
{
}
