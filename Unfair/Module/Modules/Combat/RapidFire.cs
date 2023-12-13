using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Combat
{
    public class RapidFire : Module
    {
        public RapidFire() : base("RapidFire", "Increase fire rate", Category.Combat, KeyCode.Q)
        {
        }
        
        public override void OnUpdate()
        {
            if (GameData.LocalPlayer == null || GameData.CurrentWeapon == null) return;

            GameData.CurrentWeapon.Fire();
        }
    }
}