using Libraries.Shared.Extensions;
using Libraries.Shared.Extensions.ServiceExtensions;
using StoriedKingdom.Dungeon.Database.DbContexts;

namespace StoriedKingdom.Dungeon.Extensions;

public static  class ServiceExtensions
{
    public static IServiceCollection AddStandardDatabases(this IServiceCollection services)
    {
        return services.AddStandardDatabases<ApplicationContext, AuthorizationContext>();
    }
}