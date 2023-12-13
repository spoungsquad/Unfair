using System.Collections.Generic;
using System.Threading;
using Photon.Pun;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Building
{
    public class Breakdown : Module
    {
        public Breakdown() : base("Breakdown", "Break everything", Category.Building, KeyCode.F10)
        {
        }

        // public override void OnGUI()
        // {
        //     BuildingNetworkController.Instance.KillAllBuildings(true);
        // }

        public override void OnUpdate()
        {
            PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);

            var thread = new Thread(() =>
            {
                foreach (var id in GameData.BuildingIDs)
                {
                    GameData.BuildingNetworkController.KillBuilding(id);

                    // lagspike mitigation
                    Thread.Sleep(1);
                }
            });
            thread.Start();
        }
    }
}