using Microsoft.Xna.Framework;

namespace DungeonRoguelike;

public class Character
{
    public Vector2 Position { get; private set; }

    public string Texture => "knight_m"; // TODO change to character type, etc

    public Character(Vector2 initialPosition)
    {
        Position = initialPosition;
    }
    
    public void Move(Vector2 direction)
    {
        Position += direction;
    }
}