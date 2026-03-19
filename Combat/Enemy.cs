using Microsoft.Xna.Framework;

namespace DungeonRoguelike.Combat;

public class Enemy // TODO common base class with character?
{
    private IEnemyBehaviour behaviour = new SimpleHomingBehaviour();
    
    public string Texture => "zombie"; // TODO change to enemy type, etc
    public Vector2 Position { get; private set; }
    public float MovementSpeed { get; private set; } = 2f;

    public Enemy(Vector2 initialPosition)
    {
        Position = initialPosition;
    }
    
    public void Move(Character character)
    {
        var movement = behaviour.GetMovement(this, character);
        Position += movement;
    }
}