﻿using System.Collections.Generic;
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
            panel.PositionOffset = new Vector2(0, 25);
            panel.Rect = new Rect(0, 0, Rect.size.x, Rect.size.y - 25);
            
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
                PositionOffset = new Vector2(_nextX, 0)
            };
            
            _nextX += (int)button.Rect.size.x;

            if (Children == null)
            {
                Children = new UIElement[] { button, panel };
                
                // toggle the first tab
                button.IsToggled = true;
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
            foreach (var pair in _tabs)
            {
                var button = pair.Key;
                var panel = pair.Value;
                
                if (button.IsPressed)
                {
                    foreach (var otherPair in _tabs.Where(x => x.Key != button))
                    {
                        otherPair.Key.IsToggled = false;
                    }
                    
                    button.IsToggled = true;
                }
                
                panel.IsVisible = button.IsToggled;
            }
            
            base.Draw();
        }
    }
}