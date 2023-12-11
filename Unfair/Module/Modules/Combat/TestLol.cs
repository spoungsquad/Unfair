using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.Realtime;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Combat
{
    public class TestLol : Module
    {
        private long _lastTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        public TestLol() : base("TestLol", "Testing", Category.Building, KeyCode.N)
        {
        }

        public override void OnUpdate()
        {
            PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
            

            int ms = 2000;
            long currentMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            if (Math.Abs(_lastTime - currentMs) < ms) return;

            var players = GameData.PlayerControllers.OrderBy(x =>
                Vector3.Distance(x.transform.position, GameData.LocalPlayer.transform.position)).ToList();
            players.Remove(GameData.LocalPlayer);
            var localPlayer = GameData.LocalPlayer;

            foreach (var player in players)
            {
                if (player.photonView.IsMine) continue;
                player.photonView.RPC("TakeHit", RpcTarget.All, new object[]
                {
                    1000000, player.transform.position, player.photonView.CreatorActorNr, true
                });
            }
        }
    }
}