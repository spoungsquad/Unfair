using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unfair.Util;

namespace Unfair.Module
{
    public class ModuleManager
    {
        public static List<Module> Modules = new List<Module>();

        public static void Init()
        {
            KeybindManager.LoadKeybinds();

            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsSubclassOf(typeof(Module))).OrderBy(x => x.Name))
            {
                // Check for the DebugOnly attribute
#if !DEBUG
                if (type.GetCustomAttribute<Attributes.DebugOnlyAttribute>() != null)continue;
#endif
                Module m = (Module)Activator.CreateInstance(type);

                if (KeybindManager.Keybinds.ContainsKey(m.Name))
                    m.Key = KeybindManager.Keybinds[m.Name];

                Modules.Add(m);
                DebugConsole.Write("Added module " + m.Name);
            }
            
            // Sort all modules by category
            Modules = Modules.OrderBy(x => x.Category).ToList();

            // KeybindManager.CreateKeybinds(); // ! USE THIS IF U ADD A MODULE !
        }
    }
}