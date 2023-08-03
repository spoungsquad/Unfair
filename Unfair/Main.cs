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
        private void Start()
        {
            //DebugConsole.Write("Hello, world!");
            ModuleManager.Init();

            GameData.UIManager.ShowToast(new DefaultedLocalizedString(new LocalizedString("", ""),
                "Unfair loaded!"));
        }

        private void Update()
        {
	        foreach (Module.Module module in ModuleManager.Modules)
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
			        // we can't do anything about this until we have debugging
		        }
	        }
        }

        private void OnGUI()
        {
	        UI.Arraylist.ArrayList();
	        
            foreach (Module.Module module in ModuleManager.Modules)
            {
	            if (module.Enabled)
		            module.OnGUI();
            }
        }
    }
}