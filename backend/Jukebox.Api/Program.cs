using HotChocolate.AspNetCore;
using Jukebox.Api.Infrastructure.Services;
using Jukebox.Api.Types;
using Jukebox.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Entity framework
builder.Services.AddDbContext<DatabaseContext>(
    //c => c.UseSqlServer(builder.Configuration.GetConnectionString("Jukebox")),
    c => c.UseSqlite(builder.Configuration.GetConnectionString("Jukebox")),
    ServiceLifetime.Transient,
    ServiceLifetime.Transient
);

if (builder.Environment.IsDevelopment())
{
    // Migrate database schema
    builder.Services.AddHostedService<MigrationService>();

    // Output updated schema.graphql file
    builder.Services.AddHostedService<SchemaSyncService>();
}

// Add hot chocolate and register types
builder
    .Services.AddGraphQLServer()
    .AddApiTypes()
    .AddQueryType<JukeboxQuery>()
    .AddMutationType<JukeboxMutation>()
    .AddSubscriptionType<JukeboxSubscription>()
    .ModifyOptions(x => x.DefaultBindingBehavior = BindingBehavior.Explicit)
    .AddInMemorySubscriptions();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseWebSockets();

// map traffic from /graphql into Hot Chocolate engine + turn on graphql client tool (Banana Cake Pop)
app.MapGraphQL().WithOptions(new GraphQLServerOptions { Tool = { Enable = true } });

app.RunWithGraphQLCommands(args);

namespace Jukebox.Api
{
    public partial class Program { }
}
