using Libraries.Shared.Extensions;
using Libraries.Shared.Models.OptionModels;
using StoriedKingdom.Dungeon.Enums;
using StoriedKingdom.Dungeon.Models.OptionModels;

namespace StoriedKingdom.Dungeon.Extensions;

internal static class WebApplicationBuilderExtensions
{
    private static readonly string ExternalConfigFolder =
        Libraries.Shared.Extensions.WebApplicationBuilderExtensions.ExternalConfigFolder;


    internal static WebApplicationBuilder ConfigureApplicationSettings(this WebApplicationBuilder builder)
    {
        builder.ConfigureRoleSettings().ConfigureGameSettings();

        return builder;
    }

    internal static WebApplicationBuilder ConfigureRoleSettings(this WebApplicationBuilder builder)
    {
        return
            builder
                .ConfigureAdministratorRoleSettings()
                .ConfigureDungeonMasterRoleSettings()
                .ConfigurePlayerRoleSettings();
    }


    internal static WebApplicationBuilder ConfigureDungeonMasterRoleSettings(this WebApplicationBuilder builder)
    {
         var dungeonMasterSection = $"{RoleOption.Roles}:{UserRole.DungeonMaster.GetDisplayName()}";

        builder
            .Services
            .AddOptions<RoleOption>(UserRole.DungeonMaster.ToString())
            .Bind(builder.Configuration.GetRequiredSection(dungeonMasterSection));

        return builder;
    }

    internal static WebApplicationBuilder ConfigurePlayerRoleSettings(this WebApplicationBuilder builder)
    {
        string playerSection = $"{RoleOption.Roles}:{UserRole.Player}";

        builder
            .Services
            .AddOptions<RoleOption>(UserRole.Player.ToString())
            .Bind(builder.Configuration.GetRequiredSection(playerSection));

        return builder;
    }

    internal static WebApplicationBuilder ConfigureGameSettings(this WebApplicationBuilder builder)
    {
        const string gamesFilePath = "Games.json";

        string currentDirectory = Directory.GetCurrentDirectory();
        string fullGamesFilePath = Path.Combine(currentDirectory, ExternalConfigFolder, gamesFilePath);


        builder.Configuration.AddJsonFile(fullGamesFilePath, false, true);

        builder
            .Services
            .AddOptions<List<GameOption>>(GameOption.Games)
            .Bind(builder.Configuration.GetRequiredSection(GameOption.Games));

        return builder;
    }
}