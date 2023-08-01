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
	        
	        foreach (var module in ModuleManager.Modules)
	        {
		        if (Input.GetKeyDown(module.Key))
		        {
			        module.Toggle();
		        }
		        
		        if (module.Enabled)
			        module.OnUpdate();
	        }
        }

        private void OnGUI()
        {
	        
	        
	        int index = 0;
            foreach (var module in ModuleManager.Modules)
            {
	            // Draw module info
	            GUI.Label(new Rect(5, 5 + index * 20, 1000, 20), $"{module.Name} ({module.Key}) : " + (module.Enabled ? "Enabled" : "Disabled"));
	            
	            if (module.Enabled)
		            module.OnGUI();
	            index++;
            }
            
            var method = typeof(PlayerHealth).GetMethod("Die", BindingFlags.Public | BindingFlags.Instance);
			if (method == null) return;
			
			var ptr = method.MethodHandle.Value;
			//GUI.Label(new Rect(50, 5, 1000, 20), ptr.ToString("X"));
        }
    }
}