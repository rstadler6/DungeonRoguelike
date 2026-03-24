using DungeonRoguelike.Combat;

namespace DungeonRoguelike;

public abstract class MovingEntity : Entity
{
    protected IEntityBehaviour behaviour = new SimpleHomingBehaviour();
    
    protected abstract float MovementSpeed { get; }

    public void Move(Entity target)
    {
        var movement = behaviour.GetMovement(this, target, MovementSpeed);
        Position += movement;
    }
}