using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Jukebox.Api.Tests.Infrastructure;

public class JukeboxApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    // sql server testing using testcontainers .net
    /*private readonly MsSqlContainer _dbContainer = new MsSqlBuilder()
        .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
        .WithPortBinding(1433, true)
        .WithPassword("Strong_password_123!")
        .Build();*/

    private string _databaseName = null!;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Development");
        builder.UseSetting("ConnectionStrings:Jukebox", $"Data Source={_databaseName}");
        //builder.UseSetting("ConnectionStrings:Jukebox", _dbContainer.GetConnectionString());
    }

    public async Task InitializeAsync()
    {
        _databaseName = $"test-{Guid.NewGuid():n}.db";
        await Task.CompletedTask;

        //await _dbContainer.StartAsync();
    }

    public new async Task DisposeAsync()
    {
        var file = Path.GetFullPath(_databaseName);
        if (File.Exists(file))
        {
            File.Delete(file);
        }

        await Task.CompletedTask;

        //await _dbContainer.StopAsync();
        //await _dbContainer.DisposeAsync();
    }
}
