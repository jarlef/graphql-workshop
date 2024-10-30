using HotChocolate.Types;
using Jukebox.Data;

namespace Jukebox.Api.Types.Category;

public class CategoryType : ObjectType<Genre>
{
    protected override void Configure(IObjectTypeDescriptor<Genre> descriptor)
    {
        descriptor.Name("Category");
        descriptor.Field(x => x.GenreId).Name("id");
        descriptor.Field(x => x.Name);
        descriptor.Field(x => x.Tracks);
    }
}
