using Unfair.Util;
using UnityEngine;

namespace Unfair.UI.Elements
{
    public class Panel : UIElement
    {
        public Color Color;
        public Color StrokeColor;
        public float StrokeWidth;
        
        public override void Draw()
        {
            Render.FillRect(AdjustedPosition(), Rect.size, Color);
            Render.DrawRect(AdjustedPosition(), Rect.size, StrokeColor, StrokeWidth);
            base.Draw();
        }
    }
}