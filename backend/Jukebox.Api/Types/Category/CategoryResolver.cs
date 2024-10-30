using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Jukebox.Data;

namespace Jukebox.Api.Types.Category;

[ExtendObjectType<Genre>]
public class CategoryResolver
{
    public IQueryable<Data.Track> GetTracks(
        [Parent] Genre category,
        DatabaseContext databaseContext
    )
    {
        return databaseContext.Track.Where(x => x.GenreId == category.GenreId);
    }
}
