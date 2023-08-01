using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Invector.CharacterController;
using Unfair.Module;
using Unfair.Util;
using UnityEngine;

namespace Unfair
{
    public class Main : MonoBehaviour
    {
	    private void Start()
        {
            //DebugConsole.Write("Hello, world!");
            ModuleManager.Init();
            
            
        }

	    public static PlayerController[] PlayerControllers;
	    
        private void Update()
        {
	        PlayerControllers = FindObjectsOfType<PlayerController>();
	        
	        foreach (Module.Module module in ModuleManager.Modules)
	        {
		        if (Input.GetKeyDown(module.Key))
		        {
			        module.Toggle();
		        }
		        
		        if (module.Enabled)
			        module.OnUpdate();
	        }
        }

        private unsafe void OnGUI()
        {
	        int index = 0;
            foreach (Module.Module module in ModuleManager.Modules)
            {
	            // Draw module info
	            GUI.Label(new Rect(5, 5 + index * 20, 1000, 20), $"{module.Name} ({module.Key}) : " + (module.Enabled ? "Enabled" : "Disabled"));
	            
	            if (module.Enabled)
		            module.OnGUI();
	            index++;
            }
        }
    }
}