using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonRoguelike.Graphics;

public class RoomRenderer
{
    private readonly Point _cellSize;

    public RoomRenderer(Point cellSize)
    {
        _cellSize = cellSize;
    }

    public void Draw(SpriteBatch spriteBatch, Room room, Point worldOffset, GameTime gameTime)
    {
        Draw(spriteBatch, room, worldOffset, Color.White, gameTime);
    }

    public void Draw(SpriteBatch spriteBatch, Room room, Point worldOffset, Color tint, GameTime gameTime)
    {
        int cellWidth = _cellSize.X;
        int cellHeight = _cellSize.Y;

        for (int y = 0; y < room.Height; y++)
        {
            for (int x = 0; x < room.Width; x++)
            {
                Tile tile = room.GetTile(x, y);
                TextureRegion region = AssetManager.GetRegion(tile.Type);

                var highlight = tile.Highlight + 2 > gameTime.TotalGameTime.Seconds;
                
                int drawWidth = region.Width;
                int drawHeight = region.Height;
                int drawX = worldOffset.X + (x * cellWidth);
                int drawY = worldOffset.Y + (y * cellHeight) + (cellHeight - drawHeight);

                var destination = new Rectangle(drawX, drawY, drawWidth, drawHeight);
                spriteBatch.Draw(region.Texture, destination, region.SourceRectangle, highlight ? Color.Red : tint);
            }
        }
    }
}

