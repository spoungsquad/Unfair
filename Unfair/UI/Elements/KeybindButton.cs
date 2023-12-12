using UnityEngine;

namespace Unfair.UI.Elements
{
    public class KeybindButton : Button
    {
        public KeyCode Key;
        public bool IsBinding;
        
        public override void Draw()
        {
            if (IsPressed)
            {
                IsBinding = true;
            }

            if (IsBinding && Input.anyKey) 
            {
                
                
                // Get the first key down
                foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode))) // TODO: Un-aids this
                {
                    if (Input.GetKeyDown(keyCode))
                    {
                        Key = keyCode;
                        IsBinding = false;
                        break;
                    }
                }
            }
            
            Text = IsBinding ? "..." : Key.ToString(); // TODO: Convert to use a map that converts KeyCodes like Comma to , for display
            base.Draw();
        }
    }
}