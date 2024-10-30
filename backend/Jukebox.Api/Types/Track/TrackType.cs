using System;
using HotChocolate.Types;
using Humanizer;

namespace Jukebox.Api.Types.Track;

public class TrackType : ObjectType<Data.Track>
{
    protected override void Configure(IObjectTypeDescriptor<Data.Track> descriptor)
    {
        descriptor.Field(x => x.TrackId).Name("id").Description("The track id");
        descriptor.Field(x => x.Name).Description("The track name");
        descriptor
            .Field("duration")
            .Description("The track duration in minutes and seconds (e.g 3m 20s)")
            .Resolve(x =>
                TimeSpan.FromMilliseconds(x.Parent<Data.Track>().Milliseconds).Humanize(3)
            );
        descriptor.Field(x => x.Album);
    }
}
