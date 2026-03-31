using DungeonRoguelike.Progression;
using DungeonRoguelike.UI.ViewModel;

namespace DungeonRoguelike.UI;

public class UiManager
{
    public XpBar XpBar { get; set; }
    
    public void Initialize(CharacterViewModel characterViewModel)
    {
        XpBar = new XpBar(characterViewModel);
    }
}