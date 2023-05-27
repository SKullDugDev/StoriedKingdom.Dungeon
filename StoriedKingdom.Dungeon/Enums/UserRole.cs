using System.ComponentModel.DataAnnotations;

namespace StoriedKingdom.Dungeon.Enums;

public enum UserRole
{
    [Display(Name = "Dungeon Master")]
    DungeonMaster,

    Player
}