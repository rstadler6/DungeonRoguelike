using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonRoguelike;

public class Tile
{
    public TileType Type { get; }
    public Vector2 RoomCoords { get; }
    public int? Highlight { get; set; }

    public Tile(TileType type, Vector2 roomCoords)
    {
        Type = type;
        RoomCoords = roomCoords;
    }
}