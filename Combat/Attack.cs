using Microsoft.Xna.Framework;

namespace DungeonRoguelike.Combat;

public class Attack : MovingEntity
{
    public Entity? Target { get; set; }
    
    public Attack(Vector2 position)
    {
        Position = position;
    }
    
    protected override float MovementSpeed => 4f;

    public override string Texture => "weapon_knife";

    protected override Point GetCollisionSize()
    {
        return new Point(4, 12);
    }
    
    public bool TryDamage(Entity target)
    {
        if (IsColliding(target))
        { 
            return true;
        }

        return false;
    }
}