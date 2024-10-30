namespace Jukebox.Api.Types.Track;

public class TrackType : ObjectType<Data.Track>
{
    protected override void Configure(IObjectTypeDescriptor<Data.Track> descriptor)
    {
        descriptor.Field(x => x.TrackId).Name("id");
        descriptor.Field(x => x.Name);
        descriptor.Field(x => x.Milliseconds).Name("duration");
    }
}
