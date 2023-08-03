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
            
            GUI.Label(new Rect(50, 800, 1000, 20), "hello hi");
            GUI.Label(new Rect(50, 830, 1000, 20), "buildings in network: " + GameData.BuildingIDs.Length);
            foreach (string buildingID in GameData.BuildingIDs)
            {
                GameData.BuildingNetworkController.HitBuilding(buildingID, GameData.BuildingNetworkController.GetField<Dictionary<string, Building>>("MHBIEHNOAEK")[buildingID].Health, true);
            }
        }
    }
}