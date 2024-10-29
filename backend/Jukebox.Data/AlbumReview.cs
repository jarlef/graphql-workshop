using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jukebox.Data;

public class AlbumReview
{
    [Key]
    public int AlbumReviewId { get; set; }

    public DateTime Timestamp { get; set; }
    public string Author { get; set; }
    public int? Rating { get; set; }
    public string Comment { get; set; }

    public int UpVote { get; set; }
    public int DownVote { get; set; }

    [Required]
    public int AlbumId { get; set; }

    [ForeignKey("AlbumId")]
    public virtual Album Album { get; set; }
}
