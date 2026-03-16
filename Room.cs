namespace DungeonRoguelike;

public class Room
{
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
}