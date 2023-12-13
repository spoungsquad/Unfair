using System;
using System.Collections.Generic;
using System.Linq;
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
                        // Rect = new Rect(0, 0, Display.main.renderingWidth / 2f, Display.main.renderingHeight / 2f - 20),
                        // PositionOffset = new Vector2(0, 20)
                        
                        // padding
                        Rect = new Rect(0, 0, Display.main.renderingWidth / 2f - UIElement.Padding * 2f, 
                            Display.main.renderingHeight / 2f - 20 - UIElement.Padding * 2f),
                        PositionOffset = new Vector2(UIElement.Padding, 20 + UIElement.Padding)
                    }
                }
            };

            foreach (var category in Enum.GetValues(typeof(Category)))
            {
                var moduleGroups = new List<UIElement>();
                var nextX = UIElement.Padding * 2f;
                var nextY = UIElement.Padding * 2f;
                
                // TODO: separate modules with less than 2 options into a separate group
                
                foreach (var module in ModuleManager.Modules.Where(x => x.Category == (Category)category))
                {
                    moduleGroups.Add(new GroupPanel
                    {
                        Text = module.Name,
                        TextColor = new Color(142 / 255f, 142 / 255f, 142 / 255f),
                        Color = new Color(20 / 255f, 20 / 255f, 20 / 255f),
                        StrokeColor = new Color(30 / 255f, 30 / 255f, 30 / 255f),
                        StrokeWidth = 1f,
                        Rect = new Rect(0, 0, 220, 230),
                        PositionOffset = new Vector2(nextX, nextY),
                        Children = new UIElement[]
                        {
                            new Checkbox
                            {
                                PositionOffset = new Vector2(10, 13),
                                Checked = module.Enabled,
                                Text = $"Enable {module.Name}",
                                Color = new Color(45 / 255f, 45 / 255f, 45 / 255f),
                                CheckedColor = new Color(58 / 255f, 220 / 255f, 74 / 255f),
                                TextColor = new Color(142 / 255f, 142 / 255f, 142 / 255f),
                                StrokeColor = new Color(30 / 255f, 30 / 255f, 30 / 255f),
                                StrokeWidth = 1f,
                                OnClick = checkbox =>
                                {
                                    module.Toggle();
                                    checkbox.Checked = module.Enabled;
                                }
                            }
                        }
                    });
                    
                    nextX += 220f + UIElement.Padding * 2f;
                    
                    if (nextX + 220f + UIElement.Padding * 2f > tabPanel.Rect.size.x)
                    {
                        nextX = UIElement.Padding * 2f;
                        nextY += 230f + UIElement.Padding * 2f;
                    }
                }
                
                tabPanel.AddTab(category.ToString(), new Panel
                {
                    Color = new Color(20 / 255f, 20 / 255f, 20 / 255f),
                    StrokeColor = new Color(30 / 255f, 30 / 255f, 30 / 255f),
                    StrokeWidth = 2f,
                    Children = moduleGroups.ToArray()
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
                _window.IsVisible = !_window.IsVisible;
                
                if (_window.IsVisible)
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