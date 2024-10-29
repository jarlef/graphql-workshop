using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jukebox.Data;

public class Genre
{
    [Key]
    public int GenreId { get; set; }

    [MaxLength(120)]
    public string Name { get; set; }

    public virtual ICollection<Track> Tracks { get; set; }
}
