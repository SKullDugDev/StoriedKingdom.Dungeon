using Libraries.Shared.Models.DbModels.Authentication;
using Microsoft.AspNetCore.Identity;

namespace StoriedKingdom.Dungeon.Models.DbModels;

internal sealed class DiscordUser : AppUser<ulong>
{
    internal DiscordUser(string userName, Guid auid) : base(userName, auid)
    {
    }
    internal string Discriminator { get; set; } = string.Empty;

    [ProtectedPersonalData] internal string Discord { get; set; } = string.Empty;

    [ProtectedPersonalData] internal string NormalizedDiscord { get; set; } = string.Empty;

    internal string? Avatar { get; set; }

    internal bool? Verified { get; set; }
}