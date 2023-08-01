using System;
using System.Linq;
using Unfair.Module;
using Unfair.Util;
using UnityEngine;

namespace Unfair.UI
{
    public class Arraylist
    {
        public static void ArrayList()
        {
            GUIStyle ArrayListGUIStyle = new GUIStyle();
            ArrayListGUIStyle.alignment = TextAnchor.MiddleLeft;
            ArrayListGUIStyle.fontSize = 18;

            var modules = ModuleManager.Modules.Where(module => module.Enabled);
            var orderedEnumerable = modules.OrderByDescending(module => GetTextWidth(module.Name)).ToArray();

            var count = 0;
            foreach (var module in orderedEnumerable)
            {
                count++;
                
                ArrayListGUIStyle.normal.textColor = ColorUtils.GetRainbow(9000, count * -100);


                UnityEngine.GUI.Label(new Rect(15, count * 20, 1000, 20), $"{module.Name}", ArrayListGUIStyle);
            }
        }

        private static GUIStyle StringStyle { get; } = new GUIStyle();
        
        private static float GetTextWidth(string text)
        {
            var content = new GUIContent(text);
            var size = StringStyle.CalcSize(content);
            return size.x;
        }
    }
}