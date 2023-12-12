using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Player
{
    public class GodMode : Module
    {
        public GodMode() : base("GodMode", "Be invincible to all damage", Category.Player, KeyCode.F9)
        {
            Enabled = true;
        }

        public override void OnDisable()
        {
            if (GameData.LocalPlayer is null) return;
            GameData.LocalPlayerHealth.SetPlayerImmunity(false);
        }

        public override void OnUpdate()
        {
            if (GameData.LocalPlayer is null) return;
            GameData.LocalPlayerHealth.SetPlayerImmunity(true);
        }
    }
}