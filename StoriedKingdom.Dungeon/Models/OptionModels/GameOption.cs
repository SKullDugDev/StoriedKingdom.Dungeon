namespace StoriedKingdom.Dungeon.Models.OptionModels;

public class GameOption
{
    internal const string Games = "Games";
    public string System { get; set; } = null!;

    public string Edition { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Alias { get; set; } = null!;

    public string? Alt { get; set; }

    public bool Enabled { get; set; }

}