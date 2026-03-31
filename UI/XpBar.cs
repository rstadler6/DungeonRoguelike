using DungeonRoguelike.Progression;
using DungeonRoguelike.UI.ViewModel;
using Gum.DataTypes;
using Gum.Wireframe;
using Microsoft.Xna.Framework;
using MonoGameGum;
using MonoGameGum.GueDeriving;
using RenderingLibrary.Graphics;

namespace DungeonRoguelike.UI;

public class XpBar
{
    public ColoredRectangleRuntime Background { get; }
    public ContainerRuntime BarContainer { get; }
    public ColoredRectangleRuntime Bar { get; }
    
    public XpBar(CharacterViewModel characterViewModel)
    {
        Background = new ColoredRectangleRuntime
        {
            Color = Color.DarkGray,
            Height = 30,
        };
        
        BarContainer = new ContainerRuntime
        {
            WidthUnits = DimensionUnitType.PercentageOfParent,
            HeightUnits = DimensionUnitType.PercentageOfParent,
            Height = 100,
            YOrigin = VerticalAlignment.Top,
            XOrigin = HorizontalAlignment.Center,
        };
        
        Bar = new ColoredRectangleRuntime
        {
            Color = Color.Green,
            WidthUnits = DimensionUnitType.PercentageOfParent,
            Width = 50,
            Height = 30
        };
        
        Background.Dock(Dock.FillHorizontally);
        Background.Children.Add(BarContainer);
        BarContainer.Children.Add(Bar);
        BarContainer.Dock(Dock.Fill);
        Background.AddToRoot();
        
        Bar.BindingContext = characterViewModel;
        Bar.SetBinding(nameof(Bar.Width), nameof(CharacterViewModel.ExperienceToNextLevel));
    }
}