using System;
using Unfair.Util;
using UnityEngine;

namespace Unfair.UI.Elements
{
    public class Button : UIElement
    {
        public Color Color;
        public Color TextColor;
        public Color StrokeColor;
        public float StrokeWidth;
        public string Text;
        public bool IsPressed;
        public Action<Button> OnClick;

        public override void Draw()
        {
            Vector2 position = AdjustedPosition();
            
            Render.FillRect(position, Rect.size, Color);
            Render.DrawRect(position, Rect.size, StrokeColor, StrokeWidth);
            Render.DrawString(position, Rect.size, Text, TextColor, true);
            
            IsPressed = GUI.Button(new Rect(position, Rect.size), new GUIContent(""), GUI.skin.label);
            if (IsPressed && OnClick != null)
            {
                OnClick(this);
            }
            
            base.Draw();
        }
    }
}