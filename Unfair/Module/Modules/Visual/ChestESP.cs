using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Visual
{
    public class ChestESP : Module
    {
        // Constructor
        public ChestESP() : base("ChestESP", "Allows you to see chests through walls", Category.Visuals, KeyCode.L)
        {
            Enabled = true;
        }
        
        // Called every frame
        public override void OnGUI()
        {
            // Loop through all items
            foreach (var crate in GameData.Crates)
            {
                // Get the item's position
                var position = crate.transform.position;
                
                // Get the item's screen position
                var pos = Camera.main.WorldToScreenPoint(position);
                
                if (pos.z < 0) continue;
                GUI.color = Color.yellow;

                GUI.Label(new Rect(pos.x, Screen.height - pos.y, 100, 20), "Crate");
            }
        }
    }
}