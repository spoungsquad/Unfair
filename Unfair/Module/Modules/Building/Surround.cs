using System;
using System.Linq;
using Unfair.Config.Settings;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Building
{
    public class Surround : Module
    {
        private NumberSetting _delay =
            new NumberSetting("Delay", "Delay between each box, in milliseconds", 250, 0, 1000);

        private long _lastTime;

        public Surround() : base("Surround", "Surround all players", Category.Building, KeyCode.J)
        {
            Settings.Add(_delay);
        }

        public override void OnUpdate()
        {
            int ms = 250;
            long currentMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            if (Math.Abs(_lastTime - currentMs) < ms) return;

            var players = GameData.PlayerControllers.OrderBy(x =>
                Vector3.Distance(x.transform.position, GameData.LocalPlayer.transform.position)).ToList();
            players.Remove(GameData.LocalPlayer);
            var player = players.FirstOrDefault();

            Transform transform = player.transform;
            Vector3 pos = transform.position;
            // pos += new Vector3() pos -= new Vector3(0, 1, 0);
            var rotation = transform.rotation;
            var forward = transform.forward;
            var right = transform.right;

            GameData.BuildingNetworkController.CreateBuilding(HABLAODDMOK.Floor, pos - new Vector3(0, 0.5f, 0),
                rotation);

            // GameData.BuildingNetworkController.CreateBuilding(NAMFCNDJBDF.Roof, pos + new
            // Vector3(0, 0.5f, 0), rotation);

            GameData.BuildingNetworkController.CreateBuilding(HABLAODDMOK.Floor, pos + new Vector3(0, 1.7f, 0),
                rotation);

            GameData.BuildingNetworkController.CreateBuilding(HABLAODDMOK.Wall, pos + forward * 2,
                rotation);

            GameData.BuildingNetworkController.CreateBuilding(HABLAODDMOK.Wall, pos - forward * 2,
                rotation);

            GameData.BuildingNetworkController.CreateBuilding(HABLAODDMOK.Wall, pos + right * 2,
                rotation * Quaternion.Euler(0, 90, 0));

            GameData.BuildingNetworkController.CreateBuilding(HABLAODDMOK.Wall, pos - right * 2,
                rotation * Quaternion.Euler(0, -90, 0));

            _lastTime = currentMs;
        }
    }
}