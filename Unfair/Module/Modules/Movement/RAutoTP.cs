using Photon.Pun;
using System;
using System.Linq;
using System.Threading;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Movement
{
    public class RAutoTP : Module
    {
        private int _currentTargetIndex;

        private long _lastTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        public RAutoTP() : base("RAutoTP", "Bring players to you", Category.Combat, KeyCode.O)
        {
        }

        public override void OnUpdate()
        {
            PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);

            int tpms = 250;
            long currentMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            if (Math.Abs(_lastTime - currentMs) < tpms) return;
            // Stolen from falash aimbote
            var players = GameData.PlayerControllers.OrderBy(x => Vector3.Distance(x.transform.position, GameData.LocalPlayer.transform.position)).ToList();
            players.Remove(GameData.LocalPlayer);
            if (players.Count == 0)
                return;
            if (players.Count < _currentTargetIndex)
                _currentTargetIndex = 0;
            else
                _currentTargetIndex++;
            var target = players[_currentTargetIndex];

            var camera = GameData.MainCamera;
            new Thread(() =>
            {
                target.enabled = false;
                Thread.Sleep(tpms);
                target.enabled = true;
            }).Start();

            Vector3 pos = GameData.LocalPlayer.transform.position;
            pos += camera.transform.forward * 3;
            pos += camera.transform.right * 1f;

            target.transform.position = pos;

            _lastTime = currentMs;
        }
    }
}