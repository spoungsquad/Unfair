using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Building
{
    public class OpenUp : Module
    {
        public OpenUp() : base("OpenUp", "Opens all the chests", Category.Building, KeyCode.Quote)
        {
        }
        
        public override void OnGUI()
        {
            GUI.Label(new Rect(50, 860, 1000, 20), "crates : " + GameData.Crates.Length);
            foreach (SupplyCrate crate in GameData.Crates)
            {
                crate.OpenCrate(GameData.LocalPlayer);
            }
        }
    }
}