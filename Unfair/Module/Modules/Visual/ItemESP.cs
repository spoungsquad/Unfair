using UnityEngine;

namespace Unfair.Module.Modules.Visual
{
    public class ItemESP : Module
    {
        // Constructor
        public ItemESP() : base("ItemESP", "Draws a box around items", Category.Visuals, KeyCode.L)
        {
            Enabled = true;
        }
        
        // Called every frame
        public override void OnGUI()
        {
            
            
            // Loop through all items
            foreach (var item in Main.Pickupables)
            {
                // Get the item's position
                var position = item.transform.position;
                
                // Get the item's screen position
                var pos = Camera.main.WorldToScreenPoint(position);
                
                if (pos.z < 0) continue;
                var color = Color.white;

                GUI.color = color;
                

                GUI.Label(new Rect(pos.x, Screen.height - pos.y, 100, 20), item.tag);
            }
        }
    }
}