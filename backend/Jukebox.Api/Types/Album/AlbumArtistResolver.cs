using Jukebox.Data;
using Microsoft.EntityFrameworkCore;

namespace Jukebox.Api.Types.Album;

[ExtendObjectType<Data.Album>]
public class AlbumArtistResolver
{
    public async Task<Data.Artist?> GetArtist(
        [Parent] Data.Album album,
        DatabaseContext context,
        IAlbumArtistDataLoader albumArtistDataLoader,
        CancellationToken cancellationToken
    )
    {
        /*return await context.Artist.SingleOrDefaultAsync(
            x => x.ArtistId == album.ArtistId,
            cancellationToken
        );*/
        return await albumArtistDataLoader.LoadAsync(album.AlbumId, cancellationToken);
    }
}
