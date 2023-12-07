using Playtika.Http.Constants;
using System.Collections.Generic;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Visual
{
    public class ChestESP : Module
    {
        private readonly List<SupplyCrate> _supplyCrates = new List<SupplyCrate>();

        public ChestESP() : base("ChestESP", "Allows you to see chests through walls", Category.Visuals, KeyCode.K)
        {
            Enabled = true;
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

                Render.DrawBoxOutline(new Vector2(pos.x - 10, Screen.height - pos.y - 10), 20, 20, Color.blue);
            }
        }

        public override void OnUpdate()
        {
            _supplyCrates.Clear();
            _supplyCrates.AddRange(GameData.Crates);
        }
    }
}