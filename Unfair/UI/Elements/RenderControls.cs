using System.Collections.Generic;
using UnityEngine;

namespace Unfair.UI.Elements
{
    public static class RenderControls
    {
        
        public static Vector2 CursorPos = Vector2.zero;
        
        private static List<UIElement> _elements = new List<UIElement>();
        
        
        public static void AddElement(UIElement element)
        {
            _elements.Add(element);
        }
        
        public static void Draw()
        {
            foreach (var element in _elements)
            {
                element.Draw();
            }
        }
    }
}