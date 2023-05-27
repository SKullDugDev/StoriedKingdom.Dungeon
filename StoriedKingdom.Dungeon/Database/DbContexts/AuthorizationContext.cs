using Libraries.Shared.Database.DbContexts;
using Microsoft.EntityFrameworkCore;
using StoriedKingdom.Dungeon.Models.DbModels;

namespace StoriedKingdom.Dungeon.Database.DbContexts;

internal sealed class AuthorizationContext : AuthorizationContext<DiscordUser, Role, ulong>
{
    private const string DiscordUsers = nameof(DiscordUsers);

    public AuthorizationContext(DbContextOptions<AuthorizationContext> options) : base(options)
    {
    }

    protected override string UserTableName => DiscordUsers;
    
}