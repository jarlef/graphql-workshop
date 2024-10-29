namespace Jukebox.Api.Types.User;

public static class UserStore
{
    public static User User { get; } = new() { Id = 1, Name = "Mr. Jukebox" };
}
