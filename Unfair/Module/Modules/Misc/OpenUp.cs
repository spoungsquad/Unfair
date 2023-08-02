using System.Collections.Generic;
using System.Linq;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Misc
{
    public class OpenUp : Module
    {
        public OpenUp() : base("OpenUp", "Opens all the chests", Category.Misc, KeyCode.Quote)
        {
        }
        
        public override void OnGUI()
        {
            SupplyCrate[] crates = Object.FindObjectsOfType<SupplyCrate>();
            GUI.Label(new Rect(50, 860, 1000, 20), "crates : " + crates.Length);
            foreach (SupplyCrate crate in crates)
            {
                crate.OpenCrate(PlayerController.LHFJFKJJKCG);
            }
        }
    }
}