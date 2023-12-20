using System;
using System.Collections.Generic;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Visual
{
    public class ItemESP : Module
    {
        private int _count;
        private Pickupable[] _items = Array.Empty<Pickupable>();

        // Constructor
        public ItemESP() : base("ItemESP", "Item ESP", Category.Visuals, KeyCode.None)
        {
        }

        // Called every frame
        public override void OnGUI()
        {
            if (_count++ % 60 == 0)
            {
                _items = GameData.Pickupables;
                _count = 0;
            }
            // Loop through all items
            foreach (Pickupable item in _items)
            {
                // Get the item's position
                Vector3 position = item.transform.position;

                // Get the item's screen position
                Vector3 pos = GameData.MainCamera.WorldToScreenPoint(position);

                if (pos.z < 0) continue;
                Color color = Color.white;

                string name = item.name;

                switch (item.IMFAAGNEDIP)
                {
                    case JDFMKBDHMND.BuildingAmmo:
                        color = Color.green;
                        name = "Mats";
                        break;

                    case JDFMKBDHMND.WeaponAmmo:
                        color = Color.yellow;
                        name = "Ammo";
                        break;

                    case JDFMKBDHMND.WeaponDrop:
                        color = Color.blue;
                        name = "Weapon";
                        break;

                    case JDFMKBDHMND.WeaponLevelBooster:
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