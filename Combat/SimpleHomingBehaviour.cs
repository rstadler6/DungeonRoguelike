using Microsoft.Xna.Framework;

namespace DungeonRoguelike.Combat;

public class SimpleHomingBehaviour : IEnemyBehaviour
{
    // TODO: consider GameTime?
    // TODO: targets other than the player? xp stealing?
    public Vector2 GetMovement(Enemy enemy, Entity target)
    {
        var direction = target.Position - enemy.Position;
        if (direction.Length() > 0)
            direction.Normalize();
        
        return direction * enemy.MovementSpeed;
    }
}