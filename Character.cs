using Microsoft.Xna.Framework;

namespace DungeonRoguelike;

public class Character : Entity
{
    private static readonly Point CollisionSize = new(28, 28);
    
    public string Texture => "knight_m"; // TODO change to character type, etc

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
}