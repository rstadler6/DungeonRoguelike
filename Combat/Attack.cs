using Microsoft.Xna.Framework;

namespace DungeonRoguelike.Combat;

public class Attack : MovingEntity
{
    protected override float MovementSpeed => 2f;

    protected override Point GetCollisionSize()
    {
        throw new System.NotImplementedException();
    }
}