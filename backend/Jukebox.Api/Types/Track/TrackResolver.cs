using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Jukebox.Data;

namespace Jukebox.Api.Types.Track;

[ExtendObjectType(typeof(Data.Track))]
public class TrackResolver
{
    /*[UseProjection]
    [UseSingleOrDefault]
    public IQueryable<Data.Album> GetAlbum(
        [Parent] Data.Track track,
        DatabaseContext databaseContext
    )
    {
        return databaseContext.Album.Where(x => x.AlbumId == track.AlbumId);
    }*/
}
