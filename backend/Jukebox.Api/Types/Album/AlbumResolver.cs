using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using Jukebox.Data;
using Microsoft.EntityFrameworkCore;

namespace Jukebox.Api.Types.Album;

[ExtendObjectType<Data.Album>]
public class AlbumResolver
{
    public async Task<Data.Artist> GetArtist(
        [Parent] Data.Album album,
        [Service] DatabaseContext databaseContext
    )
    {
        return await databaseContext.Artist.SingleAsync(x => x.ArtistId == album.ArtistId);
    }

    public async Task<List<Data.Track>> GetTracks(
        [Parent] Data.Album album,
        [Service] DatabaseContext databaseContext
    )
    {
        return await databaseContext.Track.Where(x => x.AlbumId == album.AlbumId).ToListAsync();
    }

    public async Task<List<AlbumReview>> GetReviews(
        [Parent] Data.Album album,
        [Service] DatabaseContext databaseContext
    )
    {
        return await databaseContext
            .AlbumReview.Where(x => x.AlbumId == album.AlbumId)
            .ToListAsync();
    }
}
