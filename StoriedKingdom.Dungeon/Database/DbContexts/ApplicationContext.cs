using Libraries.Shared.Database.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using StoriedKingdom.Dungeon.Models.DbModels;

namespace StoriedKingdom.Dungeon.Database.DbContexts;

internal sealed class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    public DbSet<Game> Games => Set<Game>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AuditableSoftDeletableConfiguration<Game>());
    }
}