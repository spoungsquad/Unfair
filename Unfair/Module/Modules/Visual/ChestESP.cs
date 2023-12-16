using Playtika.Http.Constants;
using System.Collections.Generic;
using Unfair.Config.Settings;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Visual
{
    public class ChestESP : Module
    {
        private ColorSetting _color = new ColorSetting("Color", "The color of the ESP", Color.blue);
        
        private readonly List<SupplyCrate> _supplyCrates = new List<SupplyCrate>();

        public ChestESP() : base("ChestESP", "Chest ESP", Category.Visuals, KeyCode.K)
        {
            Settings.Add(_color);
        }

        // Called every frame
        public override void OnGUI()
        {
            // Loop through all items
            foreach (var crate in _supplyCrates)
            {
                // Get the item's position
                var position = crate.transform.position;

                // Get the item's screen position
                var pos = GameData.MainCamera.WorldToScreenPoint(position);
                if (pos.z < 0) continue;

                Render.DrawRect(new Vector2(pos.x - 10, Screen.height - pos.y - 10), new Vector2(20, 20), Color.blue);
            }
        }

        public override void OnUpdate()
        {
            _supplyCrates.Clear();
            _supplyCrates.AddRange(GameData.Crates);
        }
    }
}