using System;
using System.Linq;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Misc
{
    public class Surround : Module
    {
        public Surround() : base("Surround", "Surrounds other players with builds and boxes them in", Category.Misc, KeyCode.J)
        {
        }

        private long _lastTime = 0;

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
            // pos += new Vector3()
            // pos -= new Vector3(0, 1, 0);
            var rotation = transform.rotation;
            var forward = transform.forward;
            var right = transform.right;
            
            GameData.BuildingNetworkController.CreateBuilding(LGCCJMPPPPP.Floor, pos - new Vector3(0, 0.5f, 0),
                rotation);

            // GameData.BuildingNetworkController.CreateBuilding(LGCCJMPPPPP.Roof, pos + new Vector3(0, 0.5f, 0),
            //     rotation);
            
            GameData.BuildingNetworkController.CreateBuilding(LGCCJMPPPPP.Floor, pos + new Vector3(0, 1.7f, 0),
                rotation);

            GameData.BuildingNetworkController.CreateBuilding(LGCCJMPPPPP.Wall, pos + forward * 2,
                rotation);

            GameData.BuildingNetworkController.CreateBuilding(LGCCJMPPPPP.Wall, pos - forward * 2,
                rotation);

            GameData.BuildingNetworkController.CreateBuilding(LGCCJMPPPPP.Wall, pos + right * 2,
                rotation * Quaternion.Euler(0, 90, 0));

            GameData.BuildingNetworkController.CreateBuilding(LGCCJMPPPPP.Wall, pos - right * 2,
                rotation * Quaternion.Euler(0, -90, 0));


            _lastTime = currentMs;
        }
    }
}