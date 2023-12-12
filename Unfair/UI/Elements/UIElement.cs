using System.Linq;
using UnityEngine;

namespace Unfair.UI.Elements
{
    public class UIElement
    {
        public static float Padding = 5f;
        
        public Rect Rect;
        public Vector2 PositionOffset;
        public UIElement Parent;
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
        
        protected Vector2 AdjustedPosition()
        {
            var parentPosition = Parent?.AdjustedPosition() ?? Vector2.zero;
            var scaledPosition = Parent != null ? Rect.position * Parent.Rect.size : Vector2.zero;

            return parentPosition + scaledPosition + PositionOffset;
        }
    }
}