namespace DungeonRoguelike.Presentation;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class GameplayScreen : IScreen
{
    private readonly Camera2D _camera = new();
    private readonly HUD _hud = new();
    private readonly GameSession _gameSession = new();
    private readonly InputManager _inputManager;

    public GameplayScreen(InputManager inputManager)
    {
        _inputManager = inputManager;
    }

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
}

