using Jukebox.Api.Tests.Infrastructure;
using Jukebox.Data;
using Snapshooter.Xunit;

namespace Jukebox.Api.Tests;

public class CategoriesTests(JukeboxApplicationFactory factory)
    : BaseIntegrationTest(factory),
        IAsyncLifetime
{
    [Fact]
    public async Task GetCategories_ShouldReturnAllCategories()
    {
        var result = await Client.GetCategories.ExecuteAsync();
        result.Data.MatchSnapshot();
    }

    public async Task InitializeAsync()
    {
        DbContext.Genre.Add(new Genre { Name = "Foo" });
        DbContext.Genre.Add(new Genre { Name = "Bar" });
        await DbContext.SaveChangesAsync();
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
}
