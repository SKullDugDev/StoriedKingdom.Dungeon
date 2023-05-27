using Libraries.Shared.Models.DbModels.Authorization;

namespace StoriedKingdom.Dungeon.Models.DbModels;

public sealed class Role : Role<ulong>
{
    public Role(string roleName) : base(roleName)
    {
    }

}