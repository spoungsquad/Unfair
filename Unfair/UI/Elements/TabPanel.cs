using System.Collections.Generic;
using System.Linq;
using Unfair.Util;
using UnityEngine;

namespace Unfair.UI.Elements
{
    public class TabPanel : Panel
    {
        private readonly Dictionary<ToggleButton, Panel> _tabs = new Dictionary<ToggleButton, Panel>();
        private int _nextX;

        public void AddTab(string tab, Panel panel)
        {
            panel.PositionOffset = new Vector2(0, 65);
            
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
                PositionOffset = new Vector2(_nextX, 10),
                OnClick = btn =>
                {
                    DebugConsole.Write("Clicked tab: " + btn.Text);
                    foreach (var pair in _tabs)
                    {
                        if (pair.Key.Text == btn.Text)
                        {
                            pair.Key.IsToggled = true;
                            pair.Value.IsVisible = true;
                            
                            DebugConsole.Write($"Tab shown: {pair.Key.Text} {pair.Key.IsToggled} {pair.Value.IsVisible}");
                            continue;
                        }
                        
                        pair.Key.IsToggled = false;
                        pair.Value.IsVisible = false;
                    }
                }
            };
            
            _nextX += (int)button.Rect.size.x;

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
            base.Draw();
        }
    }
}