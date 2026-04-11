using System.Collections.Generic;
using DungeonRoguelike.Combat;
using DungeonRoguelike.Infrastructure;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonRoguelike.Graphics;

public class EntityRenderer
{
    public void Draw(SpriteBatch spriteBatch, Room room, Point worldOffset, GameTime gameTime, IEnumerable<Entity> entities)
    {
        foreach (var entity in entities)
        {
            DrawEntity(spriteBatch, entity);
        }
    }

    private void DrawEntity(SpriteBatch spriteBatch, Entity entity)
    {
        var region = AssetManager.GetRegion(entity.Texture);
        spriteBatch.Draw(region.Texture, entity.Position, region.SourceRectangle, Color.White);
    }
}

