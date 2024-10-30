using Jukebox.Data;
using Microsoft.EntityFrameworkCore;

namespace Jukebox.Api.Types.Track;

[ExtendObjectType<Data.Track>]
public class TrackAlbumResolver
{
    public async Task<Data.Album?> GetAlbum(
        [Parent] Data.Track track,
        DatabaseContext context,
        ITrackAlbumsDataLoader trackAlbumsDataLoader,
        CancellationToken cancellationToken
    )
    {
        /*return await context.Album.SingleOrDefaultAsync(
            x => x.AlbumId == track.AlbumId,
            cancellationToken
        );*/

        return await trackAlbumsDataLoader.LoadAsync(track.TrackId, cancellationToken);
    }
}
