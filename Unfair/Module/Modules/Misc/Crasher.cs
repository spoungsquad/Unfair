using System.Linq;
using Photon.Pun;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Misc
{
    public class Crasher : Module
    {
        public Crasher() : base("Crasher", "Crashes other players", Category.Misc, KeyCode.None)
        {
            Enabled = false;
        }

        public override void OnUpdate()
        {
            var lp = GameData.LocalPlayer;
            lp.photonView.gameObject.SetActive(true);

            var players = GameData.PlayerControllers.OrderBy(x => Vector3.Distance(x.transform.position, GameData.LocalPlayer.transform.position)).ToList();
            players.Remove(lp);
            
            // None of this works for crashing players sadly :(
            foreach (var player in players)
            {
                if (player.photonView.IsMine) continue;
                
                PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
                player.gameObject.transform.position = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
                player.SetFrozen(true);
                player.SetGodMode(false);
                player.gameObject.SetActive(false);
                
                player.ApplyKnockback(new Vector3(float.MaxValue, float.MaxValue, float.MaxValue));
                PhotonNetwork.DestroyPlayerObjects(player.photonView.Controller);
                PhotonNetwork.Destroy(player.photonView);
                
            }
        }
    }
}