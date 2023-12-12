using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Unfair.UI.Elements
{
    public class TabPanel : Panel
    {
        private readonly Dictionary<ToggleButton, Panel> _tabs = new Dictionary<ToggleButton, Panel>();
        
        public void AddTab(string tab, Panel panel)
        {
            ToggleButton button = new ToggleButton
            {
                Text = tab,
                Color = new Color(20 / 255f, 20 / 255f, 20 / 255f),
                ToggleColor = new Color(30 / 255f, 30 / 255f, 30 / 255f),
                StrokeColor = new Color(30 / 255f, 30 / 255f, 30 / 255f),
                TextColor = new Color(104 / 255f, 104 / 255f, 104 / 255f),
                ToggleTextColor = Color.white,
                StrokeWidth = 1f,
                Rect = new Rect(0, 0, 100, 25),
                OnClick = btn =>
                {
                    foreach (var pair in _tabs)
                    {
                        pair.Key.IsToggled = false;
                    }

                    btn.IsToggled = true;
                }
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
                tab.Key.PositionOffset = new Vector2(nextX, 10);
                
                nextX += (int)tab.Key.Rect.size.x;
                tab.Value.IsVisible = tab.Key.IsToggled;
                tab.Value.PositionOffset = new Vector2(0, tab.Key.Rect.size.y + 40);   
            }

            base.Draw();
        }
    }
}