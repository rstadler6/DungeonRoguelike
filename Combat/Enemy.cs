using Microsoft.Xna.Framework;

namespace DungeonRoguelike.Combat;

public class Enemy : MovingEntity
{
    private IEntityBehaviour behaviour = new SimpleHomingBehaviour();
    
    public override string Texture => "zombie"; // TODO change to enemy type, etc
    public Rectangle CollisionBounds { get; } = new(20, 20, 28, 28);
    protected override float MovementSpeed => 2f;

    public Enemy(Vector2 initialPosition)
    {
        Position = initialPosition;
    }
    
    protected override Point GetCollisionSize() => new(16, 16);
}