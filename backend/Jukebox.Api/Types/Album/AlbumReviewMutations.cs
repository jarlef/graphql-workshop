using System;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using Jukebox.Data;

namespace Jukebox.Api.Types.Album;

[ExtendObjectType<JukeboxMutation>]
public class AlbumReviewMutations
{
    public async Task<bool> AddAlbumReview(
        AddReviewInput input,
        [Service] DatabaseContext databaseContext
    )
    {
        databaseContext.AlbumReview.Add(
            new AlbumReview()
            {
                AlbumId = input.AlbumId,
                Author = "Guest",
                Comment = input.Comment,
                Rating = input.Rating,
                Timestamp = DateTime.Now,
            }
        );

        await databaseContext.SaveChangesAsync();

        return true;
    }
}
