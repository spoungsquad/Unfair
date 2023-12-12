using Unfair.Util;
using UnityEngine;

namespace Unfair.UI.Elements
{
    public class Window : Panel
    {
        public string Title;
        public bool IsDragging = false;
        public bool IsDraggable;
        public bool IsOpen;
        
        
        public override void Draw()
        {
            // Get Mouse Position
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
            
            Vector2 adjustedPosition = AdjustedPosition();
            
            bool isMouseOver = IsDragging ? true : mousePosition.x >= adjustedPosition.x && mousePosition.x <= adjustedPosition.x + Rect.size.x &&
                                                   mousePosition.y >= adjustedPosition.y && mousePosition.y <= adjustedPosition.y + Rect.size.y;
            
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
            
            
            if (!IsOpen)
                return;


            // Free mouse
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            UnfairGUI.OldMousePosition = mousePosition;


            base.Draw();
            // Handle drawing the title bar text
            Render.DrawString(adjustedPosition, new Vector2(Rect.width, 20), Title, Color.white, true);
        }
    }
}