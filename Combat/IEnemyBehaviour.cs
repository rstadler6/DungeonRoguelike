
using Microsoft.Xna.Framework;

namespace DungeonRoguelike.Combat;

public interface IEnemyBehaviour
{
    public Vector2 GetMovement(Enemy enemy, Character character);
}