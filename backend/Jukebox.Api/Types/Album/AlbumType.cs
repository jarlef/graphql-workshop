using HotChocolate.Types;

namespace Jukebox.Api.Types.Album;

public class AlbumType : ObjectType<Data.Album>
{
    protected override void Configure(IObjectTypeDescriptor<Data.Album> descriptor)
    {
        descriptor.Field(x => x.AlbumId).Name("id");
        descriptor.Field(x => x.Title);
        descriptor.Field(x => x.Artist);
    }
}
