using System;
using System.Linq;
using System.Threading;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Movement
{
    public class RAutoTP : Module
    {
        public RAutoTP() : base("RAutoTP", "Teleports each player in the game to you client-sidedly", Category.Combat, KeyCode.O)
        {
        }
        
        private int _currentTargetIndex = 0;
        private long _lastTime = 0;
        public override void OnUpdate()
        {
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
        
            var camera = Camera.main;
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