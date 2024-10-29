namespace Jukebox.Api.Types.User;

[ExtendObjectType<JukeboxQuery>]
public class UserQueryResolver
{
    public User GetMe()
    {
        return UserStore.User;
    }
}
