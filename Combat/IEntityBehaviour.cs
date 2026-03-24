
using Microsoft.Xna.Framework;

namespace DungeonRoguelike.Combat;

public interface IEntityBehaviour
{
    public Vector2 GetMovement(Entity source, Entity target, float movementSpeed);
}