﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Jukebox.Data;

[DebuggerDisplay("{Name} (PlaylistId = {PlaylistId})")]
public class Playlist
{
    [Key]
    public int PlaylistId { get; set; }

    [Required]
    [MaxLength(120)]
    public string Name { get; set; }
}
