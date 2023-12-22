using System;
using System.Threading.Tasks;
using JustPlay.Localization;
using Unfair.Module;
using Unfair.UI.Hooks;
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
                DebugConsole.Write("Exception in OnGUI: " + e);
            }
        }

        private void Start()
        {
            try
            {
                DebugConsole.Write("Unfair starting...");
                
                WindowHook.Hook();
                ModuleManager.Init();
                UI.UnfairGUI.Init();
                
                DebugConsole.Write("Initialized modules!");

                GameData.UIManager.ShowToast(new DefaultedLocalizedString(
                    new LocalizedString("", ""),
                    "Unfair loaded!"));
            }
            catch (Exception e)
            {
                DebugConsole.Write("Exception in Start: " + e);
            }
        }

        private void Update()
        {
            try
            {
                UI.UnfairGUI.OnUpdate();
            }
            catch (Exception e)
            {
                DebugConsole.Write("Exception in UnfairGUI: " + e);
            }

            foreach (var module in ModuleManager.Modules)
            {
                try
                {
                    if (Input.GetKeyDown(module.Key))
                        module.Toggle();

                    if (module.Enabled)
                        module.OnUpdate();
                }
                catch (Exception e)
                {
                    DebugConsole.Write("Exception in module " + module.Name + ": " + e);
                }
            }

        }
    }
}