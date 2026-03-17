using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DungeonRoguelike.Input;

public class MovementManager
{
    private readonly InputManager _inputManager;
    private const float MOVEMENT_SPEED = 4.0f;

    public Room CurrentRoom { get; set; }
    
    public MovementManager(InputManager inputManager, Room room)
    {
        _inputManager = inputManager;
        CurrentRoom = room;
    }
    
    public Vector2 GetDirection(Vector2 currentPosition, GameTime gameTime)
    {
        Vector2 direction = Vector2.Zero;

        if (_inputManager.Keyboard.IsKeyDown(Keys.I))
            direction.Y -= MOVEMENT_SPEED;
        if (_inputManager.Keyboard.IsKeyDown(Keys.K))
            direction.Y += MOVEMENT_SPEED;
        if (_inputManager.Keyboard.IsKeyDown(Keys.J))
            direction.X -= MOVEMENT_SPEED;
        if (_inputManager.Keyboard.IsKeyDown(Keys.L))
            direction.X += MOVEMENT_SPEED;
        
        return CurrentRoom.CheckDirectionCollisionAndAdjust(direction, currentPosition, gameTime);
    }
    
    // TODO make diagonal movement same as normal
}