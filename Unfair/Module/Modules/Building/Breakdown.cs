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
        
        int times = 0;
        public override void OnGUI()
        {
            GUI.Label(new Rect(50, 800, 1000, 20), "hello hi");
            GUI.Label(new Rect(50, 830, 1000, 20), "buildings in network: " + GameData.BuildingIDs.Length);
            
            PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
            BuildingNetworkController.Instance.KillAllBuildings(true);
        }
    }
}