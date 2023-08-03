using Unfair.Util;
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
            foreach (Pickupable item in GameData.Pickupables)
            {
                // Get the item's position
                Vector3 position = item.transform.position;
                
                // Get the item's screen position
                Vector3 pos = Camera.main.WorldToScreenPoint(position);
                
                if (pos.z < 0) continue;
                Color color = Color.white;

                //item.PickUp(GameData.LocalPlayer, Pickupable.KDKHDANBCMA.Manual);
                
                string name = item.name;

                switch (item.GIJLLCDFMHL)
                {
                    case CGKHFFFEOPG.BuildingAmmo:
                        color = Color.green;
                        name = "Mats";
                        break;
                    case CGKHFFFEOPG.WeaponAmmo:
                        color = Color.yellow;
                        name = "Ammo";
                        break;
                    case CGKHFFFEOPG.WeaponDrop:
                        color = Color.blue;
                        name = "Weapon";
                        break;
                    case CGKHFFFEOPG.WeaponLevelBooster:
                        color = Color.magenta;
                        name = "Weapon Level Booster";
                        break;
                }
                GUI.color = color;


                GUI.Label(new Rect(pos.x, Screen.height - pos.y, 100, 20), name);
            }
        }
    }
}