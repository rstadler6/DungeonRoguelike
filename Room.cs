using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace DungeonRoguelike;

public class Room
{
    public const int TileSize = 32;
    private readonly Tile[,] _tiles;

    public Room(Tile[,] tiles)
    {
        _tiles = tiles;
    }

    public int Width => _tiles.GetLength(0);

    public int Height => _tiles.GetLength(1);

    public int WidthPixels => Width * TileSize;

    public int HeightPixels => Height * TileSize;

    public Tile GetTile(int x, int y)
    {
        return _tiles[x, y];
    }

    public Rectangle GetTileBounds(int tileX, int tileY)
    {
        return new Rectangle(tileX * TileSize, tileY * TileSize, TileSize, TileSize);
    }

    public bool IsInsideTileGrid(int tileX, int tileY)
    {
        return tileX >= 0 && tileX < Width && tileY >= 0 && tileY < Height;
    }

    public bool IsSolidTile(int tileX, int tileY)
    {
        return IsInsideTileGrid(tileX, tileY) && GetTile(tileX, tileY).Type.IsSolid();
    }

    public IEnumerable<(int X, int Y, Tile Tile)> GetTilesInBounds(Rectangle bounds)
    {
        if (bounds.Width <= 0 || bounds.Height <= 0)
            yield break;

        int minTileX = Math.Max(0, bounds.Left / TileSize);
        int minTileY = Math.Max(0, bounds.Top / TileSize);
        int maxTileX = Math.Min(Width - 1, (bounds.Right - 1) / TileSize);
        int maxTileY = Math.Min(Height - 1, (bounds.Bottom - 1) / TileSize);

        if (minTileX > maxTileX || minTileY > maxTileY)
            yield break;

        for (int x = minTileX; x <= maxTileX; x++)
        {
            for (int y = minTileY; y <= maxTileY; y++)
            {
                yield return (x, y, GetTile(x, y));
            }
        }
    }
}