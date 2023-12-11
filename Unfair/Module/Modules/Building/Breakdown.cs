using System.Collections.Generic;
using Photon.Pun;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Building
{
    public class Breakdown : Module
    {
        public Breakdown() : base("Breakdown", "Breaks everything down as fast as it can", Category.Building, KeyCode.F10)
        {
        }

        public override void OnGUI()
        {
            GUI.Label(new Rect(50, 800, 1000, 20), "hello hi");

            BuildingNetworkController.Instance.KillAllBuildings(true);
        }
    }
}