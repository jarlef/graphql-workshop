using HotChocolate.Execution;
using JetBrains.Annotations;

namespace Jukebox.Api.Infrastructure.Services;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class SchemaSyncService(IRequestExecutorResolver requestExecutorResolver) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        var defaultExecutor = await requestExecutorResolver.GetRequestExecutorAsync(
            cancellationToken: cancellationToken
        );

        await File.WriteAllTextAsync(
            "../../schema.graphql",
            defaultExecutor.Schema.ToString(),
            cancellationToken
        );
    }
}
