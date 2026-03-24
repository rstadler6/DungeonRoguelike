using Microsoft.Xna.Framework;

namespace DungeonRoguelike.Progression;

public class XpOrb : Entity
{
    public override string Texture => "blue_coin";
    
    protected override Point GetCollisionSize() => new(16, 16);

    public XpOrb(Vector2 position)
    {
        Position = position;
    }
}