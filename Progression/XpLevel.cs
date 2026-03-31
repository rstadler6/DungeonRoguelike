using Gum.Mvvm;

namespace DungeonRoguelike.Progression;

public class XpLevel : ViewModel
{ 
    public int Level { get; private set; } = 1;
    public int Experience { get; private set; }

    public int ExperienceToNextLevel { get => Get<int>(); set => Set(value); }

    public XpLevel()
    {
        Experience = 0;
        ExperienceToNextLevel = 0;
    }
    
    public void CollectExperience(int amount)
    {
        Experience += amount;
        ExperienceToNextLevel = Experience * 100 / ExperienceNeeded();
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        if (Experience >= ExperienceNeeded())
        {
            Level++;
            Experience = 0;
            ExperienceToNextLevel = 0;
        }
        // TODO level up action
    }

    private int ExperienceNeeded() => (int)(100 + Level * 0.1 * 100);
}