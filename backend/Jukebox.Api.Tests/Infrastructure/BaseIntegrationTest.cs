using JetBrains.Annotations;
using Jukebox.Api.Tests.Client;
using Jukebox.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Jukebox.Api.Tests.Infrastructure;

public abstract class BaseIntegrationTest : IClassFixture<JukeboxApplicationFactory>
{
    private readonly IServiceScope _scope;
    protected DatabaseContext DbContext { get; }
    protected IJukeboxClient Client { get; }

    protected BaseIntegrationTest(JukeboxApplicationFactory factory)
    {
        _scope = factory.Services.CreateScope();

        // get hold of servers database context
        DbContext = _scope.ServiceProvider.GetRequiredService<DatabaseContext>();

        // create graphql client (Strawberry Shake)
        var serviceCollection = new ServiceCollection();
        serviceCollection
            .AddJukeboxClient()
            .ConfigureHttpClient(
                httpClient =>
                {
                    // target the server endpoint
                    httpClient.BaseAddress = new Uri(factory.Server.BaseAddress, "graphql");
                },
                httpClientBuilder =>
                {
                    // get the http handler for the test server and register it in Strawberry Shake client
                    // so that network traffic is forwarded correctly to the test server
                    httpClientBuilder.ConfigurePrimaryHttpMessageHandler(
                        factory.Server.CreateHandler
                    );
                }
            );

        // get the starwberry shake client
        Client = serviceCollection.BuildServiceProvider().GetRequiredService<IJukeboxClient>();
    }

    [UsedImplicitly]
    public void Dispose()
    {
        DbContext.Dispose();
        _scope.Dispose();
    }
}
