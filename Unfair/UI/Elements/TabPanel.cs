using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine;

namespace Unfair.UI.Elements
{
    public class TabPanel : Panel
    {
        Dictionary<ToggleButton, Panel> _tabs = new Dictionary<ToggleButton, Panel>();
        
        public void AddTab(string tab, Panel panel)
        {
            ToggleButton button = new ToggleButton
            {
                Text = tab,
                Color = new Color(0, 0, 0 ,0),
                StrokeColor = Color.white,
                StrokeWidth = 1f,
                Rect = new UnityEngine.Rect(0, 0, 100, 20)
            };

            if (Children == null)
            {
                Children = new UIElement[] { button, panel };
            } 
            else
            {
                Children = Children.Append(button).ToArray();
                Children = Children.Append(panel).ToArray();
            }
            
            _tabs.Add(button, panel);
        }
        
        public override void Draw()
        {
            int nextX = 0;
            foreach (var tab in _tabs)
            {
                tab.Key.PositionOffset = new UnityEngine.Vector2(nextX, 10);
                
                nextX += (int)tab.Key.Rect.size.x;
                tab.Value.IsVisible = tab.Key.IsToggled;
                tab.Value.PositionOffset = new UnityEngine.Vector2(0, tab.Key.Rect.size.y + 40);   
            }

            base.Draw();
        }
    }
}