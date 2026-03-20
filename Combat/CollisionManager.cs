using Microsoft.Xna.Framework;

namespace DungeonRoguelike.Combat;

public class CollisionManager
{
    private readonly EnemyManager _enemyManager;
    private readonly Character _character;

    public CollisionManager(EnemyManager enemyManager, Character character)
    {
        _enemyManager = enemyManager;
        _character = character;
    }
    
    public bool CheckCollision(Entity entity1, Entity entity2)
    {
        return false;
        //return Rectangle.Intersect()
    }
}