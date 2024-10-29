using Jukebox.Api.Tests.Infrastructure;
using Snapshooter.Xunit;

namespace Jukebox.Api.Tests;

public class UserTests(JukeboxApplicationFactory factory) : BaseIntegrationTest(factory)
{
    [Fact]
    public async Task GetUser_ShouldReturnUser()
    {
        var result = await Client.GetUser.ExecuteAsync();
        result.Data.MatchSnapshot();
    }
}
