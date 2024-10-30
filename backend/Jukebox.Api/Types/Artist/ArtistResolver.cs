using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Jukebox.Data;

namespace Jukebox.Api.Types.Artist;

[ExtendObjectType<Data.Artist>]
public class ArtistResolver
{
    [UseProjection]
    public IQueryable<Data.Album> GetAlbums(
        [Parent] Data.Artist artist,
        DatabaseContext databaseContext
    )
    {
        return databaseContext.Album.Where(x => x.ArtistId == artist.ArtistId);
    }
}
