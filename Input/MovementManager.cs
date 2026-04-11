using DungeonRoguelike.Presentation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DungeonRoguelike.Input;

public class MovementManager
{
    private readonly InputManager _inputManager;
    private const float MovementSpeed = 4.0f;
    
    public MovementManager(InputManager inputManager)
    {
        _inputManager = inputManager;
    }
    
    public Vector2 GetDirection()
    {
        Vector2 direction = Vector2.Zero;

        if (_inputManager.Keyboard.IsKeyDown(Keys.I))
            direction.Y -= MovementSpeed;
        if (_inputManager.Keyboard.IsKeyDown(Keys.K))
            direction.Y += MovementSpeed;
        if (_inputManager.Keyboard.IsKeyDown(Keys.J))
            direction.X -= MovementSpeed;
        if (_inputManager.Keyboard.IsKeyDown(Keys.L))
            direction.X += MovementSpeed;

        return direction;
    }
    
    // TODO make diagonal movement same as normal
}