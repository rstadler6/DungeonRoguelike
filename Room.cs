using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace DungeonRoguelike;

public class Room
{
    private const int TileSize = 32; // TODO: move?
    private const float BoundaryEpsilon = 0.001f;
    private readonly Tile[,] _tiles;

    public Room(Tile[,] tiles)
    {
        _tiles = tiles;
    }

    public int Width => _tiles.GetLength(0);

    public int Height => _tiles.GetLength(1);

    public Tile GetTile(int x, int y)
    {
        return _tiles[x, y];
    }

    public Vector2 CheckDirectionCollisionAndAdjust(Vector2 direction, Vector2 currentPosition, GameTime gameTime)
    {
        if (direction == Vector2.Zero)
            return direction;
        
        float minWalkableX = TileSize;
        float minWalkableY = TileSize;
        float maxWalkableX = (Width - 1) * TileSize - TileSize + 10;
        float maxWalkableY = (Height - 1) * TileSize - TileSize;

        if (direction.X > 0)
            direction.X = Math.Min(direction.X, maxWalkableX - currentPosition.X);
        else if (direction.X < 0)
            direction.X = Math.Max(direction.X, minWalkableX - currentPosition.X);

        if (direction.Y > 0)
            direction.Y = Math.Min(direction.Y, maxWalkableY - currentPosition.Y);
        else if (direction.Y < 0)
            direction.Y = Math.Max(direction.Y, minWalkableY - currentPosition.Y);

        if (direction == Vector2.Zero)
            return direction;

        var intersectingTiles = GetIntersectingTiles(direction, currentPosition);

        foreach (var tile in intersectingTiles)
        {
            tile.Highlight = gameTime.TotalGameTime.Seconds;
            
            if (!tile.Type.IsSolid())
                continue;

            int tileX = (int)tile.RoomCoords.X;
            int tileY = (int)tile.RoomCoords.Y;

            // Keep the moving point on the correct side of each solid tile boundary.
            if (direction.X > 0) // Moving right
            {
                float maxStepX = tileX * TileSize - currentPosition.X - BoundaryEpsilon;
                direction.X = Math.Min(direction.X, Math.Max(0f, maxStepX));
            }
            else if (direction.X < 0) // Moving left
            {
                float minStepX = (tileX + 1) * TileSize - currentPosition.X + BoundaryEpsilon;
                direction.X = Math.Max(direction.X, Math.Min(0f, minStepX));
            }

            if (direction.Y > 0) // Moving down
            {
                float maxStepY = tileY * TileSize - currentPosition.Y - BoundaryEpsilon;
                direction.Y = Math.Min(direction.Y, Math.Max(0f, maxStepY));
            }
            else if (direction.Y < 0) // Moving up
            {
                float minStepY = (tileY + 1) * TileSize - currentPosition.Y + BoundaryEpsilon;
                direction.Y = Math.Max(direction.Y, Math.Min(0f, minStepY));
            }
        }

        return direction;
    }

    private IEnumerable<Tile> GetIntersectingTiles(Vector2 direction, Vector2 currentPosition)
    {
        var targetPosition = currentPosition + direction;

        int startTileX = (int)Math.Floor(currentPosition.X / TileSize);
        int startTileY = (int)Math.Floor(currentPosition.Y / TileSize);
        int endTileX = (int)Math.Floor(targetPosition.X / TileSize);
        int endTileY = (int)Math.Floor(targetPosition.Y / TileSize);

        int minTileX = Math.Max(0, Math.Min(startTileX, endTileX));
        int maxTileX = Math.Min(Width - 1, Math.Max(startTileX, endTileX));
        int minTileY = Math.Max(0, Math.Min(startTileY, endTileY));
        int maxTileY = Math.Min(Height - 1, Math.Max(startTileY, endTileY));

        if (minTileX > maxTileX || minTileY > maxTileY)
            yield break;

        for (int x = minTileX; x <= maxTileX; x++)
        {
            for (int y = minTileY; y <= maxTileY; y++)
            {
                yield return GetTile(x, y);
            }
        }
    }
}