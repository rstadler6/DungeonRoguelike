using System.Collections.Generic;
using DungeonRoguelike.Progression;
using Microsoft.Xna.Framework;
namespace DungeonRoguelike.Combat;

public class ItemManager
{
    private List<XpOrb> orbs = new();
    
    public IReadOnlyCollection<XpOrb> Orbs => orbs.AsReadOnly();
    
    public void Update(Character character, Room currentRoom, GameTime gameTime)
    {
        
    }

    public void SpawnXpOrb(Vector2 position)
    {
        orbs.Add(new XpOrb(position));
    }
}