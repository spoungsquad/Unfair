using Unfair.Util;
using UnityEngine;

namespace Unfair.UI.Elements
{
    public class Window : Panel
    {
        public string Title;
        public bool IsDragging;
        public bool IsDraggable;
        
        public override void Draw()
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
            
            Vector2 adjustedPosition = AdjustedPosition();
            
            // is dragging OR mouse is over title bar
            bool isMouseOver = IsDragging || mousePosition.x >= adjustedPosition.x && mousePosition.x <= adjustedPosition.x + Rect.size.x &&
                mousePosition.y >= adjustedPosition.y && mousePosition.y <= adjustedPosition.y + 20;
            
            if (isMouseOver && Input.GetMouseButton(0))
            {
                IsDragging = true;
                
                if (IsDraggable)
                {
                    PositionOffset += mousePosition - UnfairGUI.OldMousePosition;
                }
            } else
            {
                IsDragging = false;
            }
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            UnfairGUI.OldMousePosition = mousePosition;

            base.Draw();
            
            Render.DrawString(adjustedPosition, new Vector2(Rect.width, 20), Title, Color.white, true);
            Render.DrawLine(new Vector2(adjustedPosition.x, adjustedPosition.y + 20),
                new Vector2(adjustedPosition.x + Rect.width, adjustedPosition.y + 20),
                new Color(58 / 255f, 220 / 255f, 74 / 255f, 1), 1);
        }
    }
}