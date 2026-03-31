using System;

namespace DungeonRoguelike.Progression;

public class XpLevel
{
    public int Level { get; private set; } = 1;
    public int Experience { get; private set; }
    public int ExperiencePercent => Experience * 100 / ExperienceNeeded();

    public event Action? Changed;

    public void CollectExperience(int amount)
    {
        Experience += amount;
        while (Experience >= ExperienceNeeded())
        {
            Experience -= ExperienceNeeded();
            Level++;
        }
        Changed?.Invoke();
    }

    private int ExperienceNeeded() => (int)(100 + Level * 0.1 * 100);
}