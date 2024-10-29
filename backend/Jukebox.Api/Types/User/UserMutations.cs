using HotChocolate.Subscriptions;

namespace Jukebox.Api.Types.User;

[ExtendObjectType<JukeboxMutation>]
public class UserMutations
{
    public User ChangeUserName(string newName, [Service] ITopicEventSender sender)
    {
        var user = UserStore.User;
        user.Name = newName;
        sender.SendAsync($"/user/{user.Id}", user);
        return user;
    }
}
