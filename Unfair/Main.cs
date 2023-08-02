using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Invector.CharacterController;
using JustPlay.Localization;
using Unfair.Module;
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
            
            UiManager.PFGFOGOILPA.ShowToast(new DefaultedLocalizedString(new LocalizedString("", ""), "Unfair loaded!" ));

        }

	    public static PlayerController[] PlayerControllers;
	    public static Pickupable[] Pickupables;
	    public static SupplyCrate[] Crates;
	    
        private void Update()
        {
	        PlayerControllers = FindObjectsOfType<PlayerController>();
	        Pickupables = FindObjectsOfType<Pickupable>();
	        Crates = FindObjectsOfType<SupplyCrate>();
	        
	        foreach (var module in ModuleManager.Modules)
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

        private void OnGUI()
        {
	        UI.Arraylist.ArrayList();
	        
            foreach (var module in ModuleManager.Modules)
            {
	            if (module.Enabled)
		            module.OnGUI();
            }
        }
    }
}