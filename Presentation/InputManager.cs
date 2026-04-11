using DungeonRoguelike.Input;
using Microsoft.Xna.Framework;

namespace DungeonRoguelike.Presentation;

public class InputManager
{
    /// <summary>
    /// Gets the state information of keyboard input.
    /// </summary>
    public KeyboardInfo Keyboard { get; private set; }

    /// <summary>
    /// Gets the state information of mouse input.
    /// </summary>
    public MouseInfo Mouse { get; private set; }

    /// <summary>
    /// Creates a new InputManager.
    /// </summary>
    public InputManager()
    {
        Keyboard = new KeyboardInfo();
        Mouse = new MouseInfo();
    }
    
    /// <summary>
    /// Updates the state information for the keyboard, mouse, and gamepad inputs.
    /// </summary>
    /// <param name="gameTime">A snapshot of the timing values for the current frame.</param>
    public void Update(GameTime gameTime)
    {
        Keyboard.Update();
        Mouse.Update();
    }
    
    public Vector2 GetMovementDirection()
    {
        var direction = Vector2.Zero;
        
        if (Keyboard.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.W))
            direction.Y -= 1;
        if (Keyboard.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A))
            direction.X -= 1;
        if (Keyboard.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.S))
            direction.Y += 1;
        if (Keyboard.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.D))
            direction.X += 1;

        return direction;
    }
}