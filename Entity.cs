using Microsoft.Xna.Framework;

namespace DungeonRoguelike;

public abstract class Entity
{
    public Vector2 Position { get; protected set; }

    protected abstract Point GetCollisionSize();

    private Rectangle GetCollisionBounds()
    {
        return new Rectangle(Position.ToPoint(), GetCollisionSize());
    }
    
    public bool IsColliding(Entity other)
    {
        return GetCollisionBounds().Intersects(other.GetCollisionBounds());
    }
}