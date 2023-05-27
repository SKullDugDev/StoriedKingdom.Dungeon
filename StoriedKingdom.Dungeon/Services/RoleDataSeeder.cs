using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extensions.Hosting.AsyncInitialization;
using Libraries.Shared.Models.OptionModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using StoriedKingdom.Dungeon.Enums;
using StoriedKingdom.Dungeon.Extensions;
using StoriedKingdom.Dungeon.Models.DbModels;
using StoriedKingdom.Dungeon.Models.OptionModels;

namespace StoriedKingdom.Dungeon.Services
{
    internal class RoleDataSeeder : IAsyncInitializer
    {

        private IOptionsMonitor<RoleOption> RoleOptionMonitorMonitor { get; set; }

        private RoleManager<Role> RoleManager { get; set; }

        private IEnumerable<GameOption> GameOptions { get; set; }

        public RoleDataSeeder(IOptionsMonitor<IEnumerable<GameOption>> gameOptionsMonitor, IOptionsMonitor<RoleOption> roleOptionMonitor, RoleManager<Role> roleManager)
        {
            GameOptions = gameOptionsMonitor.Get(GameOption.Games).Where(gameOption => gameOption.Enabled == true);
            RoleOptionMonitorMonitor = roleOptionMonitor;
            RoleManager = roleManager;

        }

        public async Task InitializeAsync(CancellationToken cancellationToken = default)
        {
            if (!cancellationToken.IsCancellationRequested) await SeedRoleAsync();
        }


        private async Task SeedRoleAsync()
        {
            foreach (string roleName in Enum.GetNames<UserRole>())
            {
                var roleOption = RoleOptionMonitorMonitor.Get(roleName);

                await CreateRoleAsync(roleOption.ToRole(), roleName);

                if (roleOption.Type != RoleType.User.ToString()) continue;

                await CreateGameRoleAsync(roleOption);

            }

            ;
        }


        private async Task CreateRoleAsync(Role role, string roleName)
        {
            if (!await RoleManager.RoleExistsAsync(roleName)) await RoleManager.CreateAsync(role);
        }

        private async Task CreateGameRoleAsync(RoleOption roleOption)
        {
            foreach (var gameOption in GameOptions)
            {
                var gameRole = roleOption.ToGameRole(gameOption);

                if(!await RoleManager.RoleExistsAsync(gameRole.Name!)) await RoleManager.CreateAsync(gameRole);
            }
        }
    }
}
