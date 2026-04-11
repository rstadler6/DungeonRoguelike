namespace DungeonRoguelike.Presentation;

using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class CharacterSelectScreen : IScreen
{
    private readonly List<CharacterDefinition> _characterOptions = new();

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

    public void SelectCharacter(int index)
    {
        if (index < 0 || index >= _characterOptions.Count)
        {
            return;
        }

        _ = _characterOptions[index];
    }
}

