using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace DungeonRoguelike.Combat;

public class EnemyManager
{
    private List<Enemy> enemies = new();
    private TimeSpan lastSpawnTime = TimeSpan.Zero;
    private readonly TimeSpan spawnInterval = TimeSpan.FromSeconds(0.5);

    public IReadOnlyCollection<Enemy> Enemies => enemies.AsReadOnly();

    public void Update(Character character, Room currentRoom, GameTime gameTime)
    {
        SpawnEnemy(character.Position, currentRoom, gameTime);
        
        foreach (var enemy in enemies.ToList())
        {
            enemy.Move(character);

            if (enemy.IsColliding(character))
            {
                enemies.Remove(enemy);
            }
        }
    }
    
    public IReadOnlyCollection<Enemy> GetIntersectingEnemies(Rectangle area)
    {
        return enemies.Where(e => e.CollisionBounds.Intersects(area)).ToList();
    }

    private void SpawnEnemy(Vector2 characterPosition, Room currentRoom, GameTime gameTime)
    {
        if (gameTime.TotalGameTime - lastSpawnTime < spawnInterval)
            return;

        enemies.Add(new Enemy(GetRandomSpawnPosition(characterPosition, currentRoom)));
        lastSpawnTime = gameTime.TotalGameTime;
    }

    private Vector2 GetRandomSpawnPosition(Vector2 characterPosition, Room room)
    {
        var random = new Random();
        var spawnPosition = Vector2.Zero;

        do
        {
           spawnPosition.X = random.Next(0, room.Width * Room.TileSize); 
           spawnPosition.Y = random.Next(0, room.Height * Room.TileSize); 
        } while(Vector2.DistanceSquared(characterPosition, spawnPosition) < 2000);

        return spawnPosition;
    }
}