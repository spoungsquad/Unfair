using System.Collections.Generic;
using System.Linq;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Misc
{
    public class Breakdown : Module
    {
        public Breakdown() : base("Breakdown", "Breaks everything down as fast as it can", Category.Misc, KeyCode.F10)
        {
        }
        
        int times = 0;
        public override void OnGUI()
        {
            if (times++ % 20 != 0) return;
            times = 0;
            
            string[] builstrings = BuildingNetworkController.Instance.GetField<Dictionary<string, Building>>("FBCJOFJMLJA").Keys.ToArray();
            GUI.Label(new Rect(50, 800, 1000, 20), "hello hi");
            GUI.Label(new Rect(50, 830, 1000, 20), "buildings in network: " + builstrings.Length);
            foreach (string builstring in builstrings)
            {
                BuildingNetworkController.Instance.HitBuilding(builstring, BuildingNetworkController.Instance.GetField<Dictionary<string, Building>>("FBCJOFJMLJA")[builstring].Health, true);
            }
        }
    }
}