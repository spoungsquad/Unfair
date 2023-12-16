using System.Collections.Generic;
using System.Threading;
using Photon.Pun;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Building
{
    public class Breakdown : Module
    {
        public Breakdown() : base("Breakdown", "Break all buildings", Category.Building, KeyCode.F10)
        {
        }

        public override void OnUpdate()
        {
            BuildingNetworkController.Instance.KillAllBuildingsRemote(true);
        }
    }
}