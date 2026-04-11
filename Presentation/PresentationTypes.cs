namespace DungeonRoguelike.Presentation;

using System;

// temporary placeholder types
public sealed class CharacterDefinition
{
    public string Name { get; set; } = string.Empty;
}

public sealed class Upgrade
{
    public string Id { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
}

public sealed class Camera2D
{
}

public sealed class HUD
{
}

public sealed class GameSession
{
}

public sealed class GameStats
{
    public int Score { get; set; }
    public TimeSpan TimeSurvived { get; set; }
    public int EnemiesKilled { get; set; }
}


