using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Jukebox.Data;

[DebuggerDisplay("PlaylistId = {PlaylistId}, TrackId = {TrackId}")]
[PrimaryKey(nameof(PlaylistId), nameof(TrackId))]
public class PlaylistTrack
{
    [Column(Order = 1)]
    public int PlaylistId { get; set; }

    [Column(Order = 2)]
    public int TrackId { get; set; }

    [ForeignKey("PlaylistId")]
    public virtual Playlist Playlist { get; set; }

    [ForeignKey("TrackId")]
    public virtual Track Track { get; set; }
}
