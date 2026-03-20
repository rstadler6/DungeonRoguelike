using Microsoft.Xna.Framework;

namespace DungeonRoguelike.Combat;

public class Enemy : Entity
{
    private IEnemyBehaviour behaviour = new SimpleHomingBehaviour();
    
    public string Texture => "zombie"; // TODO change to enemy type, etc
    public Rectangle CollisionBounds { get; } = new(20, 20, 28, 28);
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

    protected override Point GetCollisionSize() => new(16, 16);
}