namespace Jukebox.Api.Types.Artist;

public class ArtistType : ObjectType<Data.Artist>
{
    protected override void Configure(IObjectTypeDescriptor<Data.Artist> descriptor)
    {
        descriptor.Field(x => x.ArtistId).Name("id");
        descriptor.Field(x => x.Name);
    }
}
