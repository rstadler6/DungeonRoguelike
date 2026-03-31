using System;
using System.Collections.Generic;
using DungeonRoguelike.Combat;
using DungeonRoguelike.Progression;
using Microsoft.Xna.Framework;

namespace DungeonRoguelike;

public class Character : Entity
{
    public XpLevel XpLevel { get; } = new();
    
    private static readonly Point CollisionSize = new(28, 28);
    private readonly IntervalTiming attackInterval = new IntervalTiming(TimeSpan.FromSeconds(1));
    
    public override string Texture => "knight_m"; // TODO change to character type, etc

    public Character(Vector2 initialPosition)
    {
        Position = initialPosition;
    }
    
    public void Move(Vector2 direction)
    {
        Position += direction;
    }
    
    protected override Point GetCollisionSize() => new(16, 16);

    public Rectangle GetCollisionBoundsAtPosition(Vector2 position)
    {
        return new Rectangle((int)position.X, (int)position.Y, CollisionSize.X, CollisionSize.Y);
    }

    public IEnumerable<Attack> GetAttack(GameTime gameTime)
    {
        if (attackInterval.IsReady(gameTime.TotalGameTime))
        {
            yield return new Attack(Position);
        }
    }
}