using System.Collections.Generic;
using DungeonRoguelike.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonRoguelike.Infrastructure;

public static class AssetManager
{
    private static readonly Dictionary<object, Texture2D> _tileTextures = new();
    private static readonly Dictionary<object, TextureRegion> _tileRegions = new();

    private static readonly IReadOnlyDictionary<TileType, string> FloorRegionNames =
        new Dictionary<TileType, string>
        {
            [TileType.Floor] = "floor",
            [TileType.FloorTop] = "floor_top",
            [TileType.FloorLeft] = "floor_left",
            [TileType.FloorCornerTopLeft] = "floor_corner_top_left",
            [TileType.FloorRight] = "floor_right",
            [TileType.FloorCornerTopRight] = "floor_corner_top_right",
            [TileType.FloorCorridor] = "floor_corridor",
            [TileType.FloorCorridorEndTop] = "floor_corridor_end_top",
            [TileType.FloorBottom] = "floor_bottom",
            [TileType.FloorCorridorSide] = "floor_corridor_side",
            [TileType.FloorCornerBottomLeft] = "floor_corner_bottom_left",
            [TileType.FloorCornerBottomRight] = "floor_corner_bottom_right",
            [TileType.FloorCorridorSideEndLeft] = "floor_corridor_side_end_left",
            [TileType.FloorCorridorSideEndRight] = "floor_corridor_side_end_right",
            [TileType.FloorCorridorEndBottom] = "floor_corridor_end_bottom",
            [TileType.FloorSurrounded] = "floor_surrounded"
        };

    private static readonly IReadOnlyDictionary<TileType, string> WallRegionNames =
        new Dictionary<TileType, string>
        {
            [TileType.WallHorizontal] = "wall_horizontal",
            [TileType.WallVertical] = "wall_vertical",
            [TileType.WallCornerTopLeft] = "wall_corner_top_left",
            [TileType.WallCornerTopRight] = "wall_corner_top_right",
            [TileType.WallCornerBottomLeft] = "wall_corner_bottom_left",
            [TileType.WallCornerBottomRight] = "wall_corner_bottom_right"
        };

    private static readonly IReadOnlyDictionary<string, string> CharacterEnemyIdleRegionNames =
        new Dictionary<string, string>
        {
            ["angel"] = "angel_idle_anim_f0",
            ["big_demon"] = "big_demon_idle_anim_f0",
            ["big_zombie"] = "big_zombie_idle_anim_f0",
            ["chort"] = "chort_idle_anim_f0",
            ["doc"] = "doc_idle_anim_f0",
            ["dwarf_f"] = "dwarf_f_idle_anim_f0",
            ["dwarf_m"] = "dwarf_m_idle_anim_f0",
            ["elf_f"] = "elf_f_idle_anim_f0",
            ["elf_m"] = "elf_m_idle_anim_f0",
            ["goblin"] = "goblin_idle_anim_f0",
            ["ice_zombie"] = "ice_zombie_anim_f0",
            ["imp"] = "imp_idle_anim_f0",
            ["knight_f"] = "knight_f_idle_anim_f0",
            ["knight_m"] = "knight_m_idle_anim_f0",
            ["lizard_f"] = "lizard_f_idle_anim_f0",
            ["lizard_m"] = "lizard_m_idle_anim_f0",
            ["masked_orc"] = "masked_orc_idle_anim_f0",
            ["muddy"] = "muddy_anim_f0",
            ["necromancer"] = "necromancer_anim_f0",
            ["ogre"] = "ogre_idle_anim_f0",
            ["orc_shaman"] = "orc_shaman_idle_anim_f0",
            ["orc_warrior"] = "orc_warrior_idle_anim_f0",
            ["pumpkin_dude"] = "pumpkin_dude_idle_anim_f0",
            ["skelet"] = "skelet_idle_anim_f0",
            ["slug"] = "slug_anim_f0",
            ["swampy"] = "swampy_anim_f0",
            ["tiny_slug"] = "tiny_slug_anim_f0",
            ["tiny_zombie"] = "tiny_zombie_idle_anim_f0",
            ["wizzard_f"] = "wizzard_f_idle_anim_f0",
            ["wizzard_m"] = "wizzard_m_idle_anim_f0",
            ["wogol"] = "wogol_idle_anim_f0",
            ["zombie"] = "zombie_anim_f10",
            ["weapon_knife"] = "weapon_knife"
        };

    private static readonly IReadOnlyDictionary<string, string> BlueCoinRegionNames =
        new Dictionary<string, string>
        {
            ["blue_coin"] = "blue_coin"
        };

    public static void LoadContent(ContentManager content)
    {
        _tileTextures.Clear();
        _tileRegions.Clear();

        TextureAtlas floorsAtlas = TextureAtlas.FromFile(content, "textures/floors_def.xml");
        TextureAtlas wallsAtlas = TextureAtlas.FromFile(content, "textures/walls_def.xml");
        TextureAtlas dungeonsIIAtlas = TextureAtlas.FromFile(content, "textures/dungeonII_def.xml");
        TextureAtlas blueCoinAtlas = TextureAtlas.FromFile(content, "textures/blue_coin_def.xml");

        LoadAtlasRegions(floorsAtlas, FloorRegionNames);
        LoadAtlasRegions(wallsAtlas, WallRegionNames);
        LoadAtlasRegions(dungeonsIIAtlas, CharacterEnemyIdleRegionNames);
        LoadAtlasRegions(blueCoinAtlas, BlueCoinRegionNames);

        _tileRegions[TileType.Door] = floorsAtlas.GetRegion("floor");

        foreach (KeyValuePair<object, TextureRegion> pair in _tileRegions)
        {
            _tileTextures[pair.Key] = CreateTextureFromRegion(pair.Value);
        }
    }

    public static TextureRegion GetRegion(TileType type) => _tileRegions[type];

    public static TextureRegion GetRegion(string type) => _tileRegions[type];

    private static void LoadAtlasRegions(TextureAtlas atlas, IReadOnlyDictionary<TileType, string> regionMap)
    {
        foreach (KeyValuePair<TileType, string> pair in regionMap)
        {
            _tileRegions[pair.Key] = atlas.GetRegion(pair.Value);
        }
    }

    private static void LoadAtlasRegions(TextureAtlas atlas, IReadOnlyDictionary<string, string> regionMap)
    {
        foreach (KeyValuePair<string, string> pair in regionMap)
        {
            _tileRegions[pair.Key] = atlas.GetRegion(pair.Value);
        }
    }

    private static Texture2D CreateTextureFromRegion(TextureRegion region)
    {
        Texture2D texture = new Texture2D(region.Texture.GraphicsDevice, region.Width, region.Height);
        Color[] pixels = new Color[region.Width * region.Height];
        region.Texture.GetData(0, region.SourceRectangle, pixels, 0, pixels.Length);
        texture.SetData(pixels);
        return texture;
    }
}