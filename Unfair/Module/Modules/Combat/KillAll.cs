using Photon.Pun;
using System;
using System.Linq;
using Unfair.Config.Settings;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Combat
{
    public class KillAll : Module
    {
        private NumberSetting _delay = new NumberSetting("Delay", "Delay between each kill, in milliseconds", 2000, 0, 10000);
        
        private long _lastTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        public KillAll() : base("KillAll", "Kill every player", Category.Building, KeyCode.N)
        {
            Settings.Add(_delay);
        }

        public override void OnUpdate()
        {
            PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);

            int ms = 2000;
            long currentMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            if (Math.Abs(_lastTime - currentMs) < ms) return;
            _lastTime = currentMs;

            var players = GameData.PlayerControllers.OrderBy(x =>
                Vector3.Distance(x.transform.position, GameData.LocalPlayer.transform.position)).ToList();
            players.Remove(GameData.LocalPlayer);

            foreach (var player in players.Where(player => !player.photonView.IsMine))
            {
                player.photonView.RPC("TakeHit", RpcTarget.All,
                    1000000, player.transform.position, player.photonView.CreatorActorNr, true);
            }
        }
    }
}