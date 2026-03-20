using Microsoft.Xna.Framework;

namespace DungeonRoguelike;

public class CollisionDetector
{
    public Vector2 ResolveMovement(Room room, Character character, Vector2 desiredMovement, GameTime gameTime)
    {
        var startPosition = character.Position;
        var resolvedPosition = startPosition;

        resolvedPosition.X = ResolveAxis(room, character, resolvedPosition, desiredMovement.X, isHorizontal: true, gameTime);
        resolvedPosition.Y = ResolveAxis(room, character, resolvedPosition, desiredMovement.Y, isHorizontal: false, gameTime);

        return resolvedPosition - startPosition;
    }
    
    // TODO: consider GameTime?
    private float ResolveAxis(Room room, Character character, Vector2 currentPosition, float delta, bool isHorizontal, GameTime gameTime)
    {
        if (delta == 0f)
            return isHorizontal ? currentPosition.X : currentPosition.Y;

        float candidateValue = (isHorizontal ? currentPosition.X : currentPosition.Y) + delta;

        var candidatePosition = isHorizontal
            ? new Vector2(candidateValue, currentPosition.Y)
            : new Vector2(currentPosition.X, candidateValue);

        var candidateBounds = character.GetCollisionBoundsAtPosition(candidatePosition);

        foreach (var (tileX, tileY, tile) in room.GetTilesInBounds(candidateBounds))
        {
            if (!tile.Type.IsSolid())
                continue;

            tile.Highlight = gameTime.TotalGameTime.Seconds;

            var tileBounds = room.GetTileBounds(tileX, tileY);
            if (!candidateBounds.Intersects(tileBounds))
                continue;

            if (isHorizontal)
            {
                if (delta > 0f)
                    candidateValue = tileBounds.Left - candidateBounds.Width;
                else
                    candidateValue = tileBounds.Right;

                candidateBounds = character.GetCollisionBoundsAtPosition(new Vector2(candidateValue, currentPosition.Y));
            }
            else
            {
                if (delta > 0f)
                    candidateValue = tileBounds.Top - candidateBounds.Height;
                else
                    candidateValue = tileBounds.Bottom;

                candidateBounds = character.GetCollisionBoundsAtPosition(new Vector2(currentPosition.X, candidateValue));
            }
        }

        return candidateValue;
    }
}