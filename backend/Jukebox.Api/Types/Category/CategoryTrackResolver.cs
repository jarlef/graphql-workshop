using Jukebox.Data;
using Microsoft.EntityFrameworkCore;

namespace Jukebox.Api.Types.Category;

[ExtendObjectType<Genre>]
public class CategoryTrackResolver
{
    public async Task<Data.Track[]> GetTracks(
        [Parent] Genre category,
        DatabaseContext context,
        CancellationToken cancellationToken
    )
    {
        return await context
            .Track.Where(x => x.GenreId == category.GenreId)
            .ToArrayAsync(cancellationToken);
    }
}
