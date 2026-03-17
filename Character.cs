using Microsoft.Xna.Framework;

namespace DungeonRoguelike;

public class Character
{
    private static readonly Point CollisionSize = new(28, 28);

    public Vector2 Position { get; private set; }

    public Rectangle CollisionBounds => GetCollisionBoundsAt(Position);

    public string Texture => "knight_m"; // TODO change to character type, etc

    public Character(Vector2 initialPosition)
    {
        Position = initialPosition;
    }
    
    public void Move(Vector2 direction)
    {
        Position += direction;
    }

    public Rectangle GetCollisionBoundsAt(Vector2 position)
    {
        return new Rectangle((int)position.X, (int)position.Y, CollisionSize.X, CollisionSize.Y);
    }
}