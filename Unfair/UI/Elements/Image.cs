using UnityEngine;

namespace Unfair.UI.Elements
{
    public class Image : UIElement
    {
        public Texture2D Texture;
        
        public override void Draw()
        {
            GUI.DrawTexture(new Rect(AdjustedPosition(), new Vector2(Texture.width, Texture.height)), Texture);
            base.Draw();
        }
    }
}