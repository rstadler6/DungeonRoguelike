using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace DungeonRoguelike.Combat;

public class EnemyManager
{
    private List<Enemy> enemies = new();
    private TimeSpan lastSpawnTime = TimeSpan.Zero;
    private readonly TimeSpan spawnInterval = TimeSpan.FromSeconds(5);

    public IReadOnlyCollection<Enemy> Enemies => enemies.AsReadOnly();

    public void Update(Character character, Room currentRoom, GameTime gameTime)
    {
        SpawnEnemy(character.Position, currentRoom, gameTime);
        enemies.ForEach(e => e.Move(character));
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
        } while((characterPosition - spawnPosition).Length() < 40);

        return spawnPosition;
    }
}