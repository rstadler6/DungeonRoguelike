using System.Collections.Generic;
using System.Linq;
using DungeonRoguelike.Progression;
using Microsoft.Xna.Framework;
namespace DungeonRoguelike.Combat;

// TODO: common supertype AttackManager/ItemManager?
public class ItemManager
{
    private List<XpOrb> orbs = new();
    private Character character;
    
    public IReadOnlyCollection<XpOrb> Orbs => orbs.AsReadOnly();
    
    public ItemManager(Character character)
    {
        this.character = character;
    }
    
    public void Update(GameTime gameTime)
    {
        foreach (var item in orbs.ToList())
        {
            if (character.IsColliding(item))
            {
                character.XpLevel.CollectExperience(10 );
                orbs.Remove(item);
            }
        }
    }

    public void SpawnXpOrb(Vector2 position)
    {
        orbs.Add(new XpOrb(position));
    }
}