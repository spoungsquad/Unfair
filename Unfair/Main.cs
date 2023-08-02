using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Invector.CharacterController;
using JustPlay.Localization;
using Unfair.Module;
using Unfair.Module.Modules.Player;
using Unfair.Util;
using UnityEngine;
using UnityEngine.Localization;

namespace Unfair
{
    public class Main : MonoBehaviour
    {
        private void Start()
        {
            //DebugConsole.Write("Hello, world!");
            ModuleManager.Init();

            UiManager.PFGFOGOILPA.ShowToast(new DefaultedLocalizedString(new LocalizedString("", ""),
                "Unfair loaded!"));
        }

	    public static PlayerController[] PlayerControllers;
	    public static Pickupable[] Pickupables;
	    
        private void Update()
        {
	        PlayerControllers = FindObjectsOfType<PlayerController>();
	        Pickupables = FindObjectsOfType<Pickupable>();
	        
	        foreach (Module.Module module in ModuleManager.Modules.Values)
	        {
		        try
		        {
			        
			        if (Input.GetKeyDown(module.Key))
			        {
				        module.Toggle();
			        }
		        
			        if (module.Enabled)
				        module.OnUpdate();
		        }
		        catch (Exception e)
		        {
			        Debug.Log(e);
		        }
	        }
        }

        private unsafe void OnGUI()
        {
	        UI.Arraylist.ArrayList();
	        
            foreach (Module.Module module in ModuleManager.Modules.Values)
            {
	            if (module.Enabled)
		            module.OnGUI();
            }
        }
    }
}