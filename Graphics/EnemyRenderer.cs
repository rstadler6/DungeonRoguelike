using System.Collections.Generic;
using DungeonRoguelike.Combat;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonRoguelike.Graphics;

public class EnemyRenderer
{
    public void Draw(SpriteBatch spriteBatch, Room room, Point worldOffset, GameTime gameTime, IEnumerable<Enemy> enemies)
    {
        foreach (var enemy in enemies)
        {
            DrawEnemy(spriteBatch, enemy);
        }
    }

    private void DrawEnemy(SpriteBatch spriteBatch, Enemy enemy)
    {
        var region = AssetManager.GetRegion(enemy.Texture);
        spriteBatch.Draw(region.Texture, enemy.Position, region.SourceRectangle, Color.White);
    }
}

