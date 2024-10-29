namespace Jukebox.Api.Types.User;

[ExtendObjectType<JukeboxSubscription>]
internal class UserSubscription
{
    [Subscribe]
    [Topic($"/user/{{{nameof(userId)}}}")]
    public User UserUpdated(int userId, [EventMessage] User user) => user;
}
