using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Player
{
    public class GodMode : Module
    {
        public GodMode() : base("GodMode", "Be invincible to all damage", Category.Player, KeyCode.F9)
        {
        }

        public override void OnUpdate()
        {
            GameData.LocalPlayerHealth.SetPlayerImmunity(true);
        }

        public override void OnDisable()
        {
            GameData.LocalPlayerHealth.SetPlayerImmunity(false);
        }
    }
}