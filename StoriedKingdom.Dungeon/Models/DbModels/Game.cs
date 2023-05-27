using Libraries.Shared.Models.DbModels.Abstractions;

namespace StoriedKingdom.Dungeon.Models.DbModels;

public class Game : AuditableSoftDeletableEntity
{
    public string System { get; set; } = null!;

    public string Edition { get; set; } = null!;

    public string Title { get; set; } = null!;
    public string Alias { get; set; } = null!;
    public string? Alt { get; set; }
    public bool Enabled { get; set; }
    public string Url { get; set; } = null!;
}