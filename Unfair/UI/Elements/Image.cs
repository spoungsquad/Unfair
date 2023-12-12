using UnityEngine;

namespace Unfair.UI.Elements
{
    public class Image : UIElement
    {
        public Texture2D Texture;
        public bool AutoSize;
        public float Scale = 1f;
        
        public override void Draw()
        {
            if (AutoSize)
            {
                Rect.size = new Vector2(Texture.width, Texture.height) * Scale;
            }
            
            GUI.DrawTexture(new Rect(AdjustedPosition(), Rect.size), Texture);
            
            base.Draw();
        }
    }
}