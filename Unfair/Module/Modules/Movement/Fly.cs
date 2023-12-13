using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Movement
{
    public class Fly : Module
    {
        // Constructor
        public Fly() : base("Fly", "Allows you to fly around the map", Category.Movement, KeyCode.G)
        {
        }

        public override void OnDisable()
        {
            GameData.LocalPlayer.SetGodMode(false);
        }

        public override void OnUpdate()
        {
            var localPlayer = GameData.LocalPlayer;
            if (localPlayer == null)
                return;

            localPlayer.gameObject.SetActive(true);
            GameData.LocalPlayer.SetGodMode(true);
        }
    }
}