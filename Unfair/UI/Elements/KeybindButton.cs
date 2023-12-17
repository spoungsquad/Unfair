using System;
using Unfair.Util;
using UnityEngine;

namespace Unfair.UI.Elements
{
    public class KeybindButton : Button
    {
        public KeyCode Key;
        public bool IsBinding;
        public Action<KeybindButton> OnKeybind;
        
        public override void Draw()
        {
            if (IsPressed)
            {
                IsBinding = true;
            }

            if (IsBinding && Input.anyKey) 
            {
                // Get the first key down
                foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode))) // TODO: Un-aids this
                {
                    if (Input.GetKeyDown(keyCode))
                    {
                        Key = keyCode;
                        IsBinding = false;
                        OnKeybind?.Invoke(this);
                        break;
                    }
                }
            }

            Text = IsBinding ? "..." : KeyToString.KeyMap[Key];
            
            var textSize = Render.MeasureString(Text);
            Rect.size = new Vector2(textSize.x + 10, Rect.size.y);
            
            base.Draw();
        }
    }
}