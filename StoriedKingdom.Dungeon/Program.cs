using Libraries.Shared.Extensions;
using Libraries.Shared.Extensions.ServiceExtensions;
using Libraries.Shared.Models.DbModels.Authorization;
using StoriedKingdom.Dungeon;
using StoriedKingdom.Dungeon.Database.DbContexts;
using StoriedKingdom.Dungeon.Extensions;
using StoriedKingdom.Dungeon.Models.DbModels;
using StoriedKingdom.Dungeon.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Custom building



builder
    .ConfigureApplicationSettings()
    .SetAllStandardConnectionStrings()
    .Services
    .AddSaveChangesAuditor()
    .AddStandardDatabases()
    .AddAuthServices<DiscordUser, DiscordUserStore, Role, AuthorizationContext, ulong>(SiteInfoConstants.BaseAccessPath,
        SiteInfoConstants.SiteName)
    .AddAsyncInitializer<AdminDataSeeder>()
    .AddAsyncInitializer<RoleDataSeeder>();


var app = builder.Build();

// initialize all async initializers
await app.InitAsync();


//var gameOptions = app.Services.GetRequiredService<IOptionsMonitor<List<GameOption>>>();
//var roleOptions = app.Services.GetRequiredService<IOptionsMonitor<RoleOptions>>();

//var adminRole = roleOptions.Get(RoleOptions.Administrator);
//var dmRole = roleOptions.Get(RoleOptions.DungeonMaster);

//IEnumerable<GameOption> test = gameOptions.Get(GameOption.Games);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


await app.RunAsync();

namespace StoriedKingdom.Dungeon
{
}