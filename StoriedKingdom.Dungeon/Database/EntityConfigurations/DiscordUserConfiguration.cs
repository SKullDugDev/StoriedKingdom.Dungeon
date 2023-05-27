using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libraries.Shared.Database.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoriedKingdom.Dungeon.Models.DbModels;

namespace StoriedKingdom.Dungeon.Database.EntityConfigurations
{
    internal class DiscordUserConfiguration : AppUserConfiguration<DiscordUser,ulong>
    {
        public override void Configure(EntityTypeBuilder<DiscordUser> builder)
        {
            base.Configure(builder);
            builder.Property(discordUser => discordUser.UserName).IsRequired();
            builder.Property(discordUser => discordUser.Discriminator).HasColumnOrder(5);
            builder.Property(discordUser => discordUser.Discord).HasColumnOrder(6);
            builder.Property(discordUser => discordUser.NormalizedDiscord).HasColumnOrder(7);
        }
    }
}
