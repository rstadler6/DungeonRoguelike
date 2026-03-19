using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DungeonRoguelike.Combat;
using DungeonRoguelike.Generation;
using DungeonRoguelike.Graphics;
using DungeonRoguelike.Input;

namespace DungeonRoguelike;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private readonly RoomGenerator _roomGenerator = new();
    private Room _room;
    private RoomRenderer _roomRenderer;
    private EnemyRenderer _enemyRenderer = new();
    private readonly InputManager _inputManager = new();
    private MovementManager _movementManager;
    private readonly CollisionDetector _collisionDetector = new();
    private readonly Character _character;
    private readonly EnemyManager _enemyManager = new();

    private readonly Vector2 InitialCharacterPosition = new(300, 300);
    private float _zoom = 2f; // Camera zoom level
    
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        
        // Set window size here
        _graphics.PreferredBackBufferWidth = 1280;
        _graphics.PreferredBackBufferHeight = 720;
        _graphics.ApplyChanges();
        
        _character = new Character(InitialCharacterPosition);
    }

    protected override void Initialize()
    {
        _room = _roomGenerator.GenerateRoom(30, 20);
        _movementManager = new MovementManager(_inputManager);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        AssetManager.LoadContent(Content);
        
        _roomRenderer = new RoomRenderer(new Point(32, 32));
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        var keyboardState = Keyboard.GetState();
        
        // Zoom controls: + and - keys
        if (keyboardState.IsKeyDown(Keys.Add) || keyboardState.IsKeyDown(Keys.OemPlus))
            _zoom = MathHelper.Clamp(_zoom + 0.1f, 0.5f, 3f);
        if (keyboardState.IsKeyDown(Keys.Subtract) || keyboardState.IsKeyDown(Keys.OemMinus))
            _zoom = MathHelper.Clamp(_zoom - 0.1f, 0.5f, 3f);

        _inputManager.Update(gameTime);
        
        var desiredMovement = _movementManager.GetDirection();
        var resolvedMovement = _collisionDetector.ResolveMovement(_room, _character, desiredMovement, gameTime);
        _character.Move(resolvedMovement);
        
        _enemyManager.Update(_character, _room, gameTime);
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: GetCameraTransform());

        _roomRenderer.Draw(_spriteBatch, _room, Point.Zero, gameTime);
        DrawCharacter(_character.Position);
        _enemyRenderer.Draw(_spriteBatch, _room, Point.Zero, gameTime, _enemyManager.Enemies);

        _spriteBatch.End();

        base.Draw(gameTime);
    }

    private Matrix GetCameraTransform()
    {
        var cameraAnchor = GetCameraAnchor();

        return Matrix.CreateTranslation(-_character.Position.X, -_character.Position.Y, 0f)
               * Matrix.CreateScale(_zoom, _zoom, 1f)
               * Matrix.CreateTranslation(cameraAnchor.X, cameraAnchor.Y, 0f);
    }

    private Vector2 GetCameraAnchor()
    {
        var viewport = GraphicsDevice.Viewport;
        return new Vector2(viewport.Width * 0.5f, viewport.Height * 0.5f);
    }

    private void DrawCharacter(Vector2 worldPosition)
    {
        var region = AssetManager.GetRegion(_character.Texture);
        _spriteBatch.Draw(region.Texture, worldPosition, region.SourceRectangle, Color.White);
    }
}