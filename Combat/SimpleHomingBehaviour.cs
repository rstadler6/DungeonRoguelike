using Microsoft.Xna.Framework;

namespace DungeonRoguelike.Combat;

public class SimpleHomingBehaviour : IEntityBehaviour
{
    // TODO: consider GameTime?
    // TODO: targets other than the player? xp stealing?
    public Vector2 GetMovement(Entity source, Entity target, float movementSpeed)
    {
        var direction = target.Position - source.Position;
        if (direction.Length() > 0)
            direction.Normalize();
        
        return direction * movementSpeed;
    }
}