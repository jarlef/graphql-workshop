using Jukebox.Data;
using Microsoft.EntityFrameworkCore;

namespace Jukebox.Api.Types.Category;

[ExtendObjectType<JukeboxQuery>]
public class CategoryQueryResolver
{
    public async Task<IList<Genre>> GetCategories(
        DatabaseContext context,
        CancellationToken cancellationToken = default
    )
    {
        return await context.Genre.ToArrayAsync(cancellationToken);
    }

    public async Task<Genre> GetCategory(
        int id,
        DatabaseContext context,
        CancellationToken cancellationToken = default
    )
    {
        return await context.Genre.SingleAsync(x => x.GenreId == id, cancellationToken);
    }
}
