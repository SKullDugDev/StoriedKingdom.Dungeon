using Extensions.Hosting.AsyncInitialization;
using Libraries.Shared.Models.DbModels.Authentication;
using Libraries.Shared.Models.DbModels.Authorization;
using Libraries.Shared.Models.OptionModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using StoriedKingdom.Dungeon.Extensions;
using StoriedKingdom.Dungeon.Models.DbModels;

namespace StoriedKingdom.Dungeon.Services
{
    public class AdminDataSeeder : IAsyncInitializer
    
    {
        private RoleOption AdminRoleOption { get; }
        private UserManager<User> UserManager { get; }

        private RoleManager<Role> RoleManager { get; }

        private string DefaultAdminPassword { get; }

        public AdminDataSeeder(IOptionsMonitor<RoleOption> adminRoleOption, UserManager<User> userManager, RoleManager<Role> roleManager, IConfiguration config)
        {
            var msg = "No Administrator options found for seeding data.";

            AdminRoleOption = adminRoleOption.Get(RoleOption.Administrator) ?? throw new ArgumentNullException(nameof(adminRoleOption), msg);

            UserManager = userManager;

            RoleManager = roleManager;

            msg = "No default Administrator password found for seeding data.";

            DefaultAdminPassword = config.GetSection(nameof(DefaultAdminPassword)).Value ?? throw new InvalidOperationException(msg);
             

        }

        public async Task InitializeAsync(CancellationToken cancellationToken = default)
        {
            if (!cancellationToken.IsCancellationRequested) await SeedAdminAsync();
        }


        private async Task SeedAdminAsync()
        {
            var admin = new User(AdminRoleOption.Name)
            {

                Id = AdminRoleOption.Id,
                LockoutEnabled = false,
                TwoFactorEnabled = false,

            };

            await CreateUserAsync(admin);

            var description = $"This user is an {AdminRoleOption.Name}";

            await CreateRoleAsync(AdminRoleOption.ToRole(description));

        }

        private async Task CreateUserAsync(User adminUser)
        {
            if(await UserManager.FindByNameAsync(AdminRoleOption.Name) is null) await UserManager.CreateAsync(adminUser, DefaultAdminPassword);
        }

        private async Task CreateRoleAsync(Role adminRole)
        {
            if (!await RoleManager.RoleExistsAsync(AdminRoleOption.Name)) await RoleManager.CreateAsync(adminRole);
        }
    }
}
