using System;
using System.Collections.Generic;
using System.Linq;
using Unfair.Module;
using Unfair.Util;
using UnityEngine;

namespace Unfair.UI
{
    public class Arraylist
    {
        private static readonly GUIStyle ArrayListGUIStyle = new GUIStyle
        {
            alignment = TextAnchor.MiddleLeft,
        };
        public static void ArrayList()
        {
            Module.Module[] modules = ModuleManager.Modules.Values.OrderByDescending(module => GetTextWidth(module.Name)
            ).ToArray();

            for (int i = 0; i < modules.Length; i++)
            {
                Module.Module module = modules[i];

                ArrayListGUIStyle.normal.textColor = module.Enabled
                    ? ColorUtils.AlternateRainbow(i, modules.Length, 0, 3f, 0.7f, 1f)
                    : ColorUtils.AlternateRainbow(i, modules.Length, 0, 3f, 0.3f, 0.5f);
                
                ArrayListGUIStyle.fontSize = 18;
                float width = GetTextWidth(modules[0].Name);
                GUI.Label(new Rect(15, i * 20, 1000, 20), $"{module.Name}", ArrayListGUIStyle);
                ArrayListGUIStyle.fontSize = 14;
                ArrayListGUIStyle.normal.textColor = Color.black;
                GUI.Label(new Rect(24 + width, (i * 20) - 2, 1000, 20), $"[{module.Key}]", ArrayListGUIStyle);
                GUI.Label(new Rect(26 + width, (i * 20) - 2, 1000, 20), $"[{module.Key}]", ArrayListGUIStyle);
                GUI.Label(new Rect(24 + width, (i * 20), 1000, 20), $"[{module.Key}]", ArrayListGUIStyle);
                GUI.Label(new Rect(26 + width, (i * 20), 1000, 20), $"[{module.Key}]", ArrayListGUIStyle);
                ArrayListGUIStyle.normal.textColor = Color.white;
                GUI.Label(new Rect(25 + width, (i * 20) - 1, 1000, 20), $"[{module.Key}]", ArrayListGUIStyle);
            }
        }
        
        private static float GetTextWidth(string text)
        {
            GUIContent content = new GUIContent(text);
            Vector2 size = ArrayListGUIStyle.CalcSize(content);
            return size.x;
        }
    }
}