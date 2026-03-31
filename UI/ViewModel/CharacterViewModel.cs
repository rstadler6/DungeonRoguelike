using System;
using DungeonRoguelike.Progression;

namespace DungeonRoguelike.UI.ViewModel;

public class CharacterViewModel : Gum.Mvvm.ViewModel, IDisposable
{
    private readonly XpLevel _xpLevel;

    public int ExperienceToNextLevel => _xpLevel.ExperiencePercent;
    public int Level => _xpLevel.Level;

    public CharacterViewModel(XpLevel xpLevel)
    {
        _xpLevel = xpLevel;
        _xpLevel.Changed += OnXpChanged;
    }

    private void OnXpChanged()
    {
        NotifyPropertyChanged(nameof(ExperienceToNextLevel));
        NotifyPropertyChanged(nameof(Level));
    }

    public void Dispose() => _xpLevel.Changed -= OnXpChanged;
}
