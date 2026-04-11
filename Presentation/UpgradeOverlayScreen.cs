namespace DungeonRoguelike.Presentation;

using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class UpgradeOverlayScreen : IScreen
{
    private List<Upgrade> _upgradeOptions = new();

    public void Update(GameTime gameTime)
    {
    }

    public void Draw(SpriteBatch spriteBatch)
    {
    }

    public void OnEnter()
    {
    }

    public void OnExit()
    {
    }

    public void DisplayOptions(List<Upgrade> options)
    {
        _upgradeOptions = options;
    }

    public void OnUpgradeSelected(string upgradeID)
    {
        _ = _upgradeOptions.Find(option => option.Id == upgradeID);
    }
}

