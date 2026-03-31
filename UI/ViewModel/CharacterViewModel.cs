using DungeonRoguelike.Progression;

namespace DungeonRoguelike.UI.ViewModel;

public class CharacterViewModel : Gum.Mvvm.ViewModel
{
    public double ExperienceToNextLevel => _xpLevel.ExperienceToNextLevel;

    private XpLevel _xpLevel;
    
    public CharacterViewModel(XpLevel xpLevel)
    {
        _xpLevel = xpLevel;
    }
}