using Unfair.Util;
using UnityEngine;

namespace Unfair.UI.Elements
{
    public class Label : UIElement
    {
        public string Text;
        public bool IsCentered;
        public Color Color;
        
        public override void Draw()
        {
            Render.DrawString(AdjustedPosition(), Text, Color, IsCentered);
            base.Draw();
        }
    }
}