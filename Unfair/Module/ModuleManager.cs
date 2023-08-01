using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Unfair.Module
{
    public class ModuleManager
    {
        public static List<Module> Modules = new List<Module>();
        
        public static void Init()
        {
            // I stole this straight from Prax
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsSubclassOf(typeof(Module))).OrderBy(x => x.Name))
            {
                Modules.Add((Module)Activator.CreateInstance(type));
            }
        }

    }
}