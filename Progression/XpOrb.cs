using Microsoft.Xna.Framework;

namespace DungeonRoguelike.Progression;

public class XpOrb : Entity
{
    public string Texture => "blue_coin";
    
    protected override Point GetCollisionSize() => new(16, 16);
}