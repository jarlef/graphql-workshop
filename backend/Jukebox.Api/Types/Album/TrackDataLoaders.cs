using Jukebox.Data;
using Microsoft.EntityFrameworkCore;

namespace Jukebox.Api.Types.Album;

internal static class AlbumDataLoaders
{
    [DataLoader]
    internal static async Task<IReadOnlyDictionary<int, Data.Artist>> GetAlbumArtistAsync(
        IReadOnlyList<int> albumIds,
        DatabaseContext context,
        CancellationToken cancellationToken
    )
    {
        return await context
            .Album.Include(x => x.Artist)
            .Where(x => albumIds.Contains(x.AlbumId))
            .ToDictionaryAsync(x => x.AlbumId, x => x.Artist, cancellationToken);
    }
}
