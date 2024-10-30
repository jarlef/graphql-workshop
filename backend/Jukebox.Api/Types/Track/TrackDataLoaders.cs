using Jukebox.Data;
using Microsoft.EntityFrameworkCore;

namespace Jukebox.Api.Types.Track;

internal static class TrackDataLoaders
{
    [DataLoader]
    internal static async Task<IReadOnlyDictionary<int, Data.Album>> GetTrackAlbumsAsync(
        IReadOnlyList<int> trackIds,
        DatabaseContext context,
        CancellationToken cancellationToken
    )
    {
        return await context
            .Track.Include(x => x.Album)
            .Where(x => trackIds.Contains(x.TrackId))
            .ToDictionaryAsync(x => x.TrackId, x => x.Album, cancellationToken);
    }
}
