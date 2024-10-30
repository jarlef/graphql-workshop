using HotChocolate.Types;
using Jukebox.Data;

namespace Jukebox.Api.Types.Album;

public class AlbumReviewType : ObjectType<AlbumReview>
{
    protected override void Configure(IObjectTypeDescriptor<AlbumReview> descriptor)
    {
        descriptor.Field(x => x.AlbumReviewId).Name("id");
        descriptor.Field(x => x.Author).Name("author");
        descriptor.Field(x => x.Comment);
        descriptor.Field(x => x.Rating);
        descriptor.Field(x => x.UpVote);
        descriptor.Field(x => x.DownVote);
        descriptor.Field(x => x.Timestamp);
    }
}
