using System.Collections.Generic;
using Unfair.Module;
using Unfair.Util;
using UnityEngine;

namespace Unfair.UI
{
    public struct Window
    {
        public Vector2 Position;
        public Vector2 Size;
        public string Title;
        public bool IsOpen;
        public bool IsDraggable;
    }
    
    public class UnfairGUI
    {
        static Window _window = new Window();
        static Vector2 _oldMousePosition;
        static bool _isDragging;
        static CursorLockMode _oldCursorLockMode;
        const int padding = 5;


        public static void Init()
        {
            _oldMousePosition = Input.mousePosition;

            _window.Position = new Vector2(100, 100);
            _window.Size = new Vector2(Display.main.renderingWidth / 2f, Display.main.renderingHeight / 2f);
            _window.Title = "Unfair";
            _window.IsOpen = true;
            _window.IsDraggable = true;
        }

        public static void OnRender()
        {
            // Get Mouse Position
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
            
            bool isMouseOver = _isDragging ? true : mousePosition.x >= _window.Position.x && mousePosition.x <= _window.Position.x + _window.Size.x &&
                               mousePosition.y >= _window.Position.y && mousePosition.y <= _window.Position.y + _window.Size.y;
            
            if (isMouseOver && Input.GetMouseButton(0))
            {
                _isDragging = true;
                
                if (_window.IsDraggable)
                {
                    _window.Position += mousePosition - _oldMousePosition;
                }
            } else
            {
                _isDragging = false;
            }
            
            
            if (!_window.IsOpen)
                return;
            
            // Free mouse
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Render.DrawRect(_window.Position, _window.Size, new Color(0.2f, 0.2f, 0.2f));
            Render.FillRect(_window.Position, _window.Size, new Color(0.1f, 0.1f, 0.1f));

            // Render centered title
            
            Vector2 titlePosition = _window.Position + new Vector2(_window.Size.x / 2, 4);
            
            Render.DrawString(titlePosition, "Unfair", Color.white, true);

            int i = 0;
            Category lastCategory = Category.None;
            int categoryCount = -1;
            foreach (var module in ModuleManager.Modules)
            {
                if (lastCategory != module.Category)
                {
                    // Render category text
                    Vector2 categoryPosition = new Vector2(_window.Position.x + 5 + ((categoryCount + 1) * ((_window.Size.x / 10) + padding)), _window.Position.y + 20);
                    Render.DrawString(categoryPosition, module.Category + ":", Color.white, false);
                    
                    lastCategory = module.Category;
                    i = 0;
                    categoryCount++;
                }
                
                Rect toggleRect = new Rect(_window.Position.x + 5 + (categoryCount * ((_window.Size.x / 10) + padding)), _window.Position.y + 35 + (i * (20 + padding / 2f)), _window.Size.x / 10, 20);
                
                if (Render.DrawButton(toggleRect, module.Name, Color.white, module.Enabled ? new Color(30f / 255f,215f / 255f,96f / 255f ) : new Color(20f / 255f,20f / 255f,20f / 255f )))
                {
                    module.Toggle();
                }
                
                i++;
            }
            
            _oldMousePosition = mousePosition;
        }

        public static void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                _window.IsOpen = !_window.IsOpen;
                
                if (_window.IsOpen)
                {
                    _oldCursorLockMode = Cursor.lockState;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
                else
                {
                    _window.Position = new Vector2(100, 100);
                    
                    Cursor.lockState = _oldCursorLockMode;
                    Cursor.visible = _oldCursorLockMode == CursorLockMode.None;
                }
            }
        }
    }
}