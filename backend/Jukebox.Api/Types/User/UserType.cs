namespace Jukebox.Api.Types.User;

public class UserType : ObjectType<User>
{
    protected override void Configure(IObjectTypeDescriptor<User> descriptor)
    {
        descriptor.Field(x => x.Id);
        descriptor.Field(x => x.Name);
    }
}
