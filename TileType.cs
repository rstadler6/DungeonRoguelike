namespace DungeonRoguelike;

public enum TileType
{
    WallHorizontal,
    WallVertical,
    WallCornerTopLeft,
    WallCornerTopRight,
    WallCornerBottomLeft,
    WallCornerBottomRight,

    Floor,
    FloorTop,
    FloorLeft,
    FloorCornerTopLeft,
    FloorRight,
    FloorCornerTopRight,
    FloorCorridor,
    FloorCorridorEndTop,
    FloorBottom,
    FloorCorridorSide,
    FloorCornerBottomLeft,
    FloorCornerBottomRight,
    FloorCorridorSideEndLeft,
    FloorCorridorSideEndRight,
    FloorCorridorEndBottom,
    FloorSurrounded,

    Door
}