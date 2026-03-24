namespace DungeonRoguelike.Progression;

public class XpLevel
{
    public int Level { get; private set; } = 1;
    public int Experience { get; private set; } = 0;
    
    public void CollectExperience(int amount)
    {
        Experience += amount;
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        if (Experience >= Level * 1.2 * 100)
        {
            Level++;
            Experience = 0;
        }
        // TODO level up action
    }
}