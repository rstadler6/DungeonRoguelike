using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DungeonRoguelike.Combat;
using DungeonRoguelike.Generation;
using DungeonRoguelike.Graphics;
using DungeonRoguelike.Input;
using DungeonRoguelike.UI;
using DungeonRoguelike.UI.ViewModel;
using Gum.Forms;
using MonoGameGum;

namespace DungeonRoguelike;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private readonly RoomGenerator _roomGenerator = new();
    private Room _room;
    private RoomRenderer _roomRenderer;
    private EntityRenderer _entityRenderer = new();
    private readonly InputManager _inputManager = new();
    private MovementManager _movementManager;
    private readonly CollisionDetector _collisionDetector = new();
    private readonly Character _character;
    private ItemManager _itemManager;
    private EnemyManager _enemyManager;
    private AttackManager _attackManager;
    private UiManager _uiManager = new();

    private readonly Vector2 InitialCharacterPosition = new(300, 300);
    private float _zoom = 2f; // Camera zoom level
    
    GumService GumUI => GumService.Default;
    
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
        GumUI.Initialize(this, DefaultVisualsVersion.V3);
        _room = _roomGenerator.GenerateRoom(30, 20);
        _movementManager = new MovementManager(_inputManager);
        _itemManager = new ItemManager(_character);
        _enemyManager = new EnemyManager();
        _attackManager = new AttackManager(_enemyManager, _character);
        _uiManager.Initialize(new CharacterViewModel(_character.XpLevel));
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
        GumUI.Update(gameTime);
        
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
        _attackManager.Update(gameTime);
        _itemManager.Update(gameTime);
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: GetCameraTransform());

        _roomRenderer.Draw(_spriteBatch, _room, Point.Zero, gameTime);
        
        _entityRenderer.Draw(_spriteBatch, _room, Point.Zero, gameTime, _enemyManager.Enemies);
        _entityRenderer.Draw(_spriteBatch, _room, Point.Zero, gameTime, _itemManager.Orbs);
        _entityRenderer.Draw(_spriteBatch, _room, Point.Zero, gameTime, _attackManager.Attacks);
        
        DrawCharacter(_character.Position);

        _spriteBatch.End();

        GumUI.Draw();
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