using Microsoft.Xna.Framework;

namespace DungeonRoguelike.Combat;

public class SimpleHomingBehaviour : IEnemyBehaviour
{
    // TODO: consider GameTime?
    public Vector2 GetMovement(Enemy enemy, Character character)
    {
        var direction = character.Position - enemy.Position;
        if (direction.Length() > 0)
            direction.Normalize();
        
        return direction * enemy.MovementSpeed;
    }
}