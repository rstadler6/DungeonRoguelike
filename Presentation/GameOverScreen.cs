namespace DungeonRoguelike.Presentation;

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class GameOverScreen : IScreen
{
    private int _score;
    private TimeSpan _timeSurvived;
    private int _enemiesKilled;

    public void Update(GameTime gameTime)
    {
    }

    public void Draw(SpriteBatch spriteBatch)
    {
    }

    public void OnEnter()
    {
    }

    public void OnExit()
    {
    }

    public void DisplayStats(GameStats stats)
    {
        _score = stats.Score;
        _timeSurvived = stats.TimeSurvived;
        _enemiesKilled = stats.EnemiesKilled;
    }
}

