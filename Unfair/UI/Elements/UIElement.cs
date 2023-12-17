using System.Linq;
using UnityEngine;

namespace Unfair.UI.Elements
{
    // common origin points:
    public static class OriginPoints
    {
        public static Vector2 TopLeft = new Vector2(0f, 0f);
        public static Vector2 TopCenter = new Vector2(0.5f, 0f);
        public static Vector2 TopRight = new Vector2(1f, 0f);
        public static Vector2 MiddleLeft = new Vector2(0f, 0.5f);
        public static Vector2 Center = new Vector2(0.5f, 0.5f);
        public static Vector2 MiddleRight = new Vector2(1f, 0.5f);
        public static Vector2 BottomLeft = new Vector2(0f, 1f);
        public static Vector2 BottomCenter = new Vector2(0.5f, 1f);
        public static Vector2 BottomRight = new Vector2(1f, 1f);
    }
    
    public class UIElement
    {
        public static float Padding = 5f;
        
        public Rect Rect; // NOTE: x and y are from 0 to 1; they are not pixel coordinates
        public Vector2 PositionOffset; // these are pixel coordinates
        public Vector2 Origin; // aka anchor/pivot point - also from 0 to 1
        
        public UIElement Parent; // position will be relative to parent
        public UIElement[] Children;
        public bool IsVisible = true;

        public virtual void Draw()
        {
            if (Children == null || Children.Length == 0) return;
            foreach (var child in Children.Where(x => x.IsVisible))
            {
                child.Parent = this;
                child.Draw();
            }
        }
        
        // kinda ripped straight from livesweeper, just Unity-ified
        public Vector2 AdjustedPosition()
        {
            var parentPosition = Parent?.AdjustedPosition() ?? Vector2.zero;
            var absoluteOrigin = Rect.size * Origin;
            
            var containerSize = Parent?.Rect.size ?? new Vector2(Screen.width, Screen.height);
            var absolutePosition = containerSize * Rect.position;
            
            return parentPosition + absolutePosition - absoluteOrigin + PositionOffset;
        }
    }
}