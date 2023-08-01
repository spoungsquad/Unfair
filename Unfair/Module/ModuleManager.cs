using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unfair.Module.Modules.Movement;
using Unfair.Module.Modules.Visual;

namespace Unfair.Module
{
    public class ModuleManager
    {
        public static Dictionary<string, Module> Modules = new Dictionary<string, Module>();
        
        public static void Init()
        {
            // I stole this straight from Prax
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsSubclassOf(typeof(Module))).OrderBy(x => x.Name))
            {
                Module m = (Module)Activator.CreateInstance(type);
                Modules.Add(m.Name, m);
            }
            
            // Sort by keyid
            Modules = Modules.OrderBy(x => x.Value.Key).ToDictionary(x => x.Key, x => x.Value);
        }
        
        
    }
}