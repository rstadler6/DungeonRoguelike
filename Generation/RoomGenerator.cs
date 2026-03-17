using Microsoft.Xna.Framework;

namespace DungeonRoguelike.Generation;

public class RoomGenerator
{
    public Room GenerateRoom(int width, int height)
    {
        var tiles = new Tile[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                tiles[x, y] = new Tile(DetermineTileType(width, height, x, y), new Vector2(x, y));
            }
        }

        return new Room(tiles);
    }

    private TileType DetermineTileType(int width, int height, int x, int y)
    {
        var isLeft = x == 0;
        var isRight = x == width - 1;
        var isTop = y == 0;
        var isBottom = y == height - 1;
        var isTopFloor = y == 1;
        var isBottomFloor = y == height - 2;
        var isLeftFloor = x == 1;
        var isRightFloor = x == width - 2;

        if (isTop && isLeft)
        {
            return TileType.WallCornerTopLeft;
        }
        if (isTop && isRight)
        {
            return TileType.WallCornerTopRight;
        }
        if (isBottom && isLeft)
        {
            return TileType.WallCornerBottomLeft;
        }
        if (isBottom && isRight)
        {
            return TileType.WallCornerBottomRight;
        }
        if (isTop)
        {
            return TileType.WallHorizontal;
        }
        if (isBottom)
        {
            return TileType.WallHorizontal;
        }
        if (isLeft)
        {
            return TileType.WallVertical;
        }
        if (isRight)
        {
            return TileType.WallVertical;
        }
        if (isTopFloor)
        {
            if (isLeftFloor)
            {
                return TileType.FloorCornerTopLeft;
            }
            if (isRightFloor) 
            {
                return TileType.FloorCornerTopRight; 
            }
            
            return TileType.FloorTop;
        }
        if (isBottomFloor)
        {
            if (isLeftFloor)
            {
                return TileType.FloorCornerBottomLeft;
            }
            if (isRightFloor) 
            {
                return TileType.FloorCornerBottomRight; 
            }
            
            return TileType.FloorBottom;
        }
        if (isLeftFloor)
        {
            return TileType.FloorLeft;
        }
        if (isRightFloor)
        {
            return TileType.FloorRight;
        }

        return TileType.Floor;
    }
}