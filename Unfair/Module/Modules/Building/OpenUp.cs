using Unfair.Config.Settings;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Building
{
    public class OpenUp : Module
    {
        private BoolSetting _teleportItems = new BoolSetting("TeleportItems", "Teleport items to you", false);
        public OpenUp() : base("OpenUp", "Open all chests", Category.Building, KeyCode.Quote)
        {
            Settings.Add(_teleportItems);
        }
        
        public override void OnGUI()
        {
            //GUI.Label(new Rect(50, 860, 1000, 20), "crates : " + GameData.Crates.Length);
            foreach (SupplyCrate crate in GameData.Crates)
            {
                crate.OpenCrate(GameData.LocalPlayer);
            }
        }
    }
}