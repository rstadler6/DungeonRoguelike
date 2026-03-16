using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DungeonRoguelike.Generation;
using DungeonRoguelike.Graphics;
using DungeonRoguelike.Input;

namespace DungeonRoguelike;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private readonly RoomGenerator _roomGenerator = new RoomGenerator();
    private Room _room;
    private RoomRenderer _roomRenderer;
    private readonly InputManager _inputManager = new InputManager();
    private readonly MovementManager _movementManager; 
    private readonly Character _character;
    
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _movementManager = new MovementManager(_inputManager);
        _character = new Character(new Vector2(100, 100));
    }

    protected override void Initialize()
    {

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        AssetManager.LoadContent(Content);

        _room = _roomGenerator.GenerateRoom(30, 20);
        _roomRenderer = new RoomRenderer(new Point(16, 16), 2f);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _inputManager.Update(gameTime);
        
        var direction = _movementManager.GetDirection();
        _character.Move(direction);
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        _roomRenderer.Draw(_spriteBatch, _room, _character.Position.ToPoint());
        DrawCharacter();
        _spriteBatch.End();

        base.Draw(gameTime);
    }
    
    private void DrawCharacter()
    {
        var region = AssetManager.GetRegion(_character.Texture);
        _spriteBatch.Draw(region.Texture, new Vector2(100, 100), region.SourceRectangle, Color.White);
    }
}