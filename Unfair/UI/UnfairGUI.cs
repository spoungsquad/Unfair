using System;
using Unfair.Module;
using Unfair.UI.Elements;
using Unfair.Util;
using UnityEngine;

namespace Unfair.UI
{
    public static class UnfairGUI
    {
        private static Window _window;
        public static Vector2 OldMousePosition;
        public static CursorLockMode OldCursorLockMode;

        public static void Init() 
        {
            OldMousePosition = Input.mousePosition;

            TabPanel tabPanel;
            _window = new Window
            {
                Rect = new Rect(0, 0, Display.main.renderingWidth / 2f, Display.main.renderingHeight / 2f),
                PositionOffset = new Vector2(100, 100),
                Title = "Unfair - a spoung squad production",
                IsOpen = true,
                IsDraggable = true,
                Color = new Color(20 / 255f, 20 / 255f, 20 / 255f),
                StrokeColor = new Color(30 / 255f, 30 / 255f, 30 / 255f),
                StrokeWidth = 2f,
                Children = new UIElement[]
                {
                    new Image
                    {
                        Texture = Spoung.DeployTheSpoung(),
                        AutoSize = true,
                        Scale = 0.5f,
                        Rect = new Rect(1f, 1f, 0, 0), // size is set in AutoSize
                        Origin = OriginPoints.BottomRight
                    },
                    tabPanel = new TabPanel
                    {
                        Rect = new Rect(0, 0, Display.main.renderingWidth / 2f, Display.main.renderingHeight / 2f - 20),
                        PositionOffset = new Vector2(0, 20)
                    }
                }
            };

            foreach (var category in Enum.GetValues(typeof(Category)))
            {
                tabPanel.AddTab(category.ToString(), new Panel
                {
                    Color = new Color(20 / 255f, 20 / 255f, 20 / 255f, 0.5f),
                    StrokeColor = new Color(30 / 255f, 30 / 255f, 30 / 255f, 0.5f),
                    StrokeWidth = 2f,
                    Children = new UIElement[]
                    {
                        new Button
                        {
                            Text = "Test",
                            Color = Color.white,
                            StrokeColor = Color.black,
                            StrokeWidth = 1f,
                            Rect = new Rect(0, 0, 100, 20),
                            PositionOffset = new Vector2(100, 100),
                            OnClick = btn =>
                            {
                                DebugConsole.Write($"{btn.Text} was clicked!");
                            }
                        }
                    }
                });
            }
            
            RenderControls.AddElement(_window);
        }

        public static void OnRender()
        {
            RenderControls.Draw();
        }

        public static void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                _window.IsOpen = !_window.IsOpen;
                
                if (_window.IsOpen)
                {
                    OldCursorLockMode = Cursor.lockState;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
                else
                {
                    _window.Rect.position = new Vector2(100, 100);
                    
                    Cursor.lockState = OldCursorLockMode;
                    Cursor.visible = OldCursorLockMode == CursorLockMode.None;
                }
            }
        }
    }
}