using System.Collections.Generic;
using Unfair.UI.Elements;
using UnityEngine;

namespace Unfair.UI
{
    public static class RenderControls
    {
        private static readonly List<UIElement> _elements = new List<UIElement>();
        
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