using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libraries.Shared.Extensions;
using Libraries.Shared.Models.OptionModels;
using StoriedKingdom.Dungeon.Models.DbModels;
using StoriedKingdom.Dungeon.Models.OptionModels;

namespace StoriedKingdom.Dungeon.Extensions
{
    internal static class RoleOptionExtensions
    {
        internal static Role ToRole(this RoleOption roleOption, string? description = null)
        {

            return new Role(roleOption.Name)
            {
                Id = (ulong)roleOption.Id,
                Alias = roleOption.Alias,
                Type = roleOption.Type,
                Description = description ?? $"This user is a {roleOption.Name}."
            };
        }


        internal static Role ToGameRole(this RoleOption roleOption, GameOption gameOption)
        {
            string roleName = roleOption.Name.PrependString(gameOption.Alt ?? gameOption.Alias, true);

            return new Role(roleName)
            {
                Id = (ulong)roleOption.Id,
                Alias = roleOption.Alias,
                Type = roleOption.Type,
                Description = $"This user is a {roleName}."
            };

        }
    }
}
