namespace Jukebox.Api.Types.Album;

public class AddReviewInput
{
    public required int AlbumId { get; set; }
    public required string Comment { get; set; }
    public int? Rating { get; set; }
}
