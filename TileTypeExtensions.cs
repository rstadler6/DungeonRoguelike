namespace DungeonRoguelike;

public static class TileTypeExtensions
{
    public static bool IsSolid(this TileType tileType) => tileType switch
    {
        TileType.WallHorizontal or
        TileType.WallVertical or
        TileType.WallCornerTopLeft or
        TileType.WallCornerTopRight or
        TileType.WallCornerBottomLeft or
        TileType.WallCornerBottomRight => true,
    
        _ => false
    };
    
}