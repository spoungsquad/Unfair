using Photon.Pun;
using Unfair.Config.Settings;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Building
{
    public class OpenUp : Module
    {
        private readonly BoolSetting _bringItems = new BoolSetting("Bring items", "Teleport all drops to self", true);

        public OpenUp() : base("OpenUp", "Open all chests", Category.Building, KeyCode.Quote)
        {
            Settings.Add(_bringItems);
        }

        public override void OnUpdate()
        {
            foreach (SupplyCrate crate in GameData.Crates)
            {
                crate.OpenCrate(GameData.LocalPlayer);
            }

            if (_bringItems.Value)
            {
                PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer); //needed
                foreach (var drop in GameData.Pickupables)
                {
                    drop.transform.position = GameData.LocalPlayer.transform.position;
                }
            }
        }
    }
}