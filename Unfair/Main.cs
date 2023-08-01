using System;
using System.Reflection;
using System.Runtime.InteropServices;
using HarmonyLib;
using Invector.CharacterController;
using Photon.Pun;
using Unfair.Module;
using Unfair.Util;
using UnityEngine;

namespace Unfair
{
    public class Main : MonoBehaviour
    {
	    public Harmony Harmony;
	    
        private void Start()
        {
            //DebugConsole.Write("Hello, world!");
            ModuleManager.Init();
            Console.Write("Unfair loaded");
        }

        public static PlayerController[] PlayerControllers;

        private void Update()
        {
            PlayerControllers = FindObjectsOfType<PlayerController>();

            foreach (var module in Module.ModuleManager.Modules)
            {
                if (Input.GetKeyDown(module.Key))
                    module.Toggle();
                
                if (module.Enabled)
                    module.OnUpdate();
            }
            
        }

        private void OnGUI()
        {
            GUI.Label(new Rect(5, 5, 1000, 20), "Unfair Loaded");

            int index = 0;
            foreach (var module in Module.ModuleManager.Modules)
            {
                if (module.Enabled)
                    module.OnGUI();
                
                // Print module name + key + enabled
                
                GUI.Label(new Rect(5, 20 + index * 20, 1000, 20), $"{module.Name} [{module.Key}] {(module.Enabled ? "Enabled" : "Disabled")}");
                
                index++;
            }
        }
    }
}