using Microsoft.EntityFrameworkCore;

namespace Jukebox.Data;

public class DatabaseContext(DbContextOptions<DatabaseContext> contextOptions)
    : DbContext(contextOptions)
{
    public DbSet<Genre> Genre { get; set; }
    public DbSet<Album> Album { get; set; }
    public DbSet<Track> Track { get; set; }
    public DbSet<Artist> Artist { get; set; }
    public DbSet<AlbumReview> AlbumReview { get; set; }

    public DbSet<Customer> Customer { get; set; }

    public DbSet<Employee> Employee { get; set; }

    public DbSet<Invoice> Invoice { get; set; }

    public DbSet<InvoiceLine> InvoiceLine { get; set; }

    public DbSet<MediaType> MediaType { get; set; }

    public DbSet<Playlist> Playlist { get; set; }

    public DbSet<PlaylistTrack> PlaylistTrack { get; set; }
}
