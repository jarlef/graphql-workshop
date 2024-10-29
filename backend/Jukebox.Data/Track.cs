using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Jukebox.Data;

[DebuggerDisplay("{Name} (TrackId = {TrackId})")]
public class Track
{
    [Key]
    public int TrackId { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; }

    public int AlbumId { get; set; }

    public int MediaTypeId { get; set; }

    public int GenreId { get; set; }

    [MaxLength(220)]
    public string Composer { get; set; }

    public int Milliseconds { get; set; }

    public int Bytes { get; set; }

    public decimal UnitPrice { get; set; }

    [ForeignKey("AlbumId")]
    public virtual Album Album { get; set; }

    [ForeignKey("MediaTypeId")]
    public virtual MediaType MediaType { get; set; }

    [ForeignKey("GenreId")]
    public virtual Genre Genre { get; set; }
}
