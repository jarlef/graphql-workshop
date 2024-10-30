using HotChocolate.Types;

namespace Jukebox.Api.Types.Album;

public class AddReviewInputType : InputObjectType<AddReviewInput>
{
    protected override void Configure(IInputObjectTypeDescriptor<AddReviewInput> descriptor)
    {
        descriptor.Field(x => x.AlbumId);
        descriptor.Field(x => x.Comment);
        descriptor.Field(x => x.Rating);
    }
}
