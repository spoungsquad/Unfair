using System;
using System.Linq;
using Photon.Pun;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Building
{
    public class TestLol : Module
    {
        public TestLol() : base("TestLol", "Testing", Category.Building, KeyCode.R)
        {
        }
        
        
        private long _lastTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        
        public override void OnUpdate()
        {
            int ms = 2000;
            long currentMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            if (Math.Abs(_lastTime - currentMs) < ms) return;

            var players = GameData.PlayerControllers.OrderBy(x =>
                Vector3.Distance(x.transform.position, GameData.LocalPlayer.transform.position)).ToList();
            players.Remove(GameData.LocalPlayer);
            var localPlayer = GameData.LocalPlayer;
            
            GameData.ThirdPersonController.IsGliding = false;

            PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
            
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