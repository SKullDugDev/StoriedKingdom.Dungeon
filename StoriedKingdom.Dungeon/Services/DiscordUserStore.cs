using Libraries.Shared.Services;
using Microsoft.AspNetCore.Identity;
using StoriedKingdom.Dungeon.Database.DbContexts;
using StoriedKingdom.Dungeon.Models.DbModels;

namespace StoriedKingdom.Dungeon.Services;

internal sealed class DiscordUserStore : AppUserStore<DiscordUser, Role, AuthorizationContext, ulong>
{
    public DiscordUserStore(AuthorizationContext context, IdentityErrorDescriber? describer = null) : base(context, describer)
    {
    }

    public override async Task<IdentityResult> CreateAsync(DiscordUser user,
        CancellationToken cancellationToken = default)
    {
        user.Discord = $"{user.UserName}#{user.Discriminator}";
        user.NormalizedDiscord = $"{user.NormalizedUserName}#{user.Discriminator}";

        return await base.CreateAsync(user, cancellationToken);
    }
}