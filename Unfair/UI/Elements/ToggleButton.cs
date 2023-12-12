using System;
using Unfair.Util;
using UnityEngine;

namespace Unfair.UI.Elements
{
    public class ToggleButton : UIElement
    {
        public Color Color;
        public Color ToggleColor;
        public Color TextColor;
        public Color ToggleTextColor;
        public Color StrokeColor;
        public float StrokeWidth;
        public string Text;
        public bool IsPressed;
        public Action<ToggleButton> OnClick;
        public bool IsToggled;
        
        public override void Draw()
        {
            Vector2 position = AdjustedPosition();
            
            var color = IsToggled ? ToggleColor : Color;
            var textColor = IsToggled ? ToggleTextColor : TextColor;
            
            Render.FillRect(position, Rect.size, color);
            Render.DrawRect(position, Rect.size, StrokeColor, StrokeWidth);
            Render.DrawString(position, Rect.size, Text, textColor, true);
            
            IsPressed = GUI.Button(new Rect(position, Rect.size), new GUIContent(""), GUI.skin.label);
            if (IsPressed && OnClick != null)
            {
                OnClick(this);
            }
            
            if (IsPressed)
                IsToggled = !IsToggled;
            
            base.Draw();
        }
    }
}