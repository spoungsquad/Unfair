using System;
using System.Threading.Tasks;
using JustPlay.Localization;
using Unfair.Module;
using Unfair.Util;
using UnityEngine;
using UnityEngine.Localization;

namespace Unfair
{
    public class Main : MonoBehaviour
    {
        private void OnGUI()
        {
            try
            {
                UI.Arraylist.ArrayList();
                UI.UnfairGUI.OnRender();

                foreach (Module.Module module in ModuleManager.Modules)
                {
                    if (module.Enabled)
                        module.OnGUI();
                }
            }
            catch (Exception e)
            {
                DebugConsole.Write(e.Message);
                DebugConsole.Write(e.StackTrace);
            }
        }

        private void Start()
        {
            try
            {
                UI.UnfairGUI.Init();
                DebugConsole.Write("Hello, world!");
                ModuleManager.Init();
                DebugConsole.Write("Initialized modules!");

                GameData.UIManager.ShowToast(new DefaultedLocalizedString(
                    new LocalizedString("", ""),
                    "Unfair loaded!"));
            }
            catch (Exception e)
            {
                DebugConsole.Write(e.Message);
                DebugConsole.Write(e.StackTrace);
            }
        }

        private void Update()
        {
            try
            {
                UI.UnfairGUI.OnUpdate();

                foreach (var module in ModuleManager.Modules)
                {
                    
                    if (Input.GetKeyDown(module.Key))
                        module.Toggle();

                    if (module.Enabled)
                        module.OnUpdate();
                }
            }
            catch (Exception e)
            {
                DebugConsole.Write(e.Message);
                DebugConsole.Write(e.StackTrace);
            }
        }
    }
}