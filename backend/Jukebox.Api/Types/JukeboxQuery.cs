using JetBrains.Annotations;
using Jukebox.Data;

namespace Jukebox.Api.Types;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class JukeboxQuery
{
    [UseProjection]
    public IQueryable<Genre> GetCategories([Service] DatabaseContext context)
    {
        return context.Genre;
    }

    [UseProjection]
    [UseSingleOrDefault]
    public IQueryable<Genre> GetCategory(int id, [Service] DatabaseContext context)
    {
        return context.Genre.Where(x => x.GenreId == id);
    }

    [UseProjection]
    public IQueryable<Data.Artist> GetArtists([Service] DatabaseContext context)
    {
        return context.Artist;
    }

    [UseProjection]
    [UseSingleOrDefault]
    public IQueryable<Data.Artist> GetArtist(int id, [Service] DatabaseContext context)
    {
        return context.Artist.Where(x => x.ArtistId == id);
    }

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Data.Album> GetAlbums([Service] DatabaseContext context)
    {
        return context.Album;
    }

    [UseProjection]
    [UseSingleOrDefault]
    public IQueryable<Data.Album> GetAlbum(int id, [Service] DatabaseContext context)
    {
        return context.Album.Where(x => x.AlbumId == id);
    }

    [UseProjection]
    [UseSingleOrDefault]
    public IQueryable<Data.Track> GetTrack(int id, [Service] DatabaseContext context)
    {
        return context.Track.Where(x => x.TrackId == id);
    }
}
