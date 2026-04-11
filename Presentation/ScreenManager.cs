namespace DungeonRoguelike.Presentation;

using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class ScreenManager
{
    private readonly Stack<IScreen> _screens = new();

    public void PushScreen(IScreen screen)
    {
        if (_screens.TryPeek(out var currentScreen))
        {
            currentScreen.OnExit();
        }

        _screens.Push(screen);
        screen.OnEnter();
    }

    public void PopScreen()
    {
        if (_screens.Count == 0)
        {
            return;
        }

        var removedScreen = _screens.Pop();
        removedScreen.OnExit();

        if (_screens.TryPeek(out var nextScreen))
        {
            nextScreen.OnEnter();
        }
    }

    public void Update(GameTime gameTime)
    {
        if (_screens.TryPeek(out var currentScreen))
        {
            currentScreen.Update(gameTime);
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if (_screens.TryPeek(out var currentScreen))
        {
            currentScreen.Draw(spriteBatch);
        }
    }
}