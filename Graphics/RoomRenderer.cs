using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonRoguelike.Graphics;

public class RoomRenderer
{
    private readonly Point _cellSize;
    private readonly float _scale;

    public RoomRenderer(Point cellSize, float scale = 1f)
    {
        _cellSize = cellSize;
        _scale = scale;
    }

    public void Draw(SpriteBatch spriteBatch, Room room, Point worldOffset)
    {
        Draw(spriteBatch, room, worldOffset, Color.White);
    }

    public void Draw(SpriteBatch spriteBatch, Room room, Point worldOffset, Color tint)
    {
        int scaledCellWidth = (int)(_cellSize.X * _scale);
        int scaledCellHeight = (int)(_cellSize.Y * _scale);

        for (int y = 0; y < room.Height; y++)
        {
            for (int x = 0; x < room.Width; x++)
            {
                Tile tile = room.GetTile(x, y);
                TextureRegion region = AssetManager.GetRegion(tile.Type);

                int drawWidth = (int)(region.Width * _scale);
                int drawHeight = (int)(region.Height * _scale);
                int drawX = worldOffset.X + (x * scaledCellWidth);
                int drawY = worldOffset.Y + (y * scaledCellHeight) + (scaledCellHeight - drawHeight);

                var destination = new Rectangle(drawX, drawY, drawWidth, drawHeight);
                spriteBatch.Draw(region.Texture, destination, region.SourceRectangle, tint);
            }
        }
    }
}

