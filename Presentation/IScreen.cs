namespace DungeonRoguelike.Presentation;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public interface IScreen
{
    void Update(GameTime gameTime);

    void Draw(SpriteBatch spriteBatch);

    void OnEnter();

    void OnExit();
}

