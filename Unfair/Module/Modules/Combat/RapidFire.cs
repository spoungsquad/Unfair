using Unfair.Config.Settings;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Combat
{
    public class RapidFire : Module
    {
        private NumberSetting _fireRate = new NumberSetting("New fire rate", "Modify fire rate, in milliseconds", 0, 0, 1000);
        
        private long _lastTime;
        
        public RapidFire() : base("RapidFire", "Modify fire rate", Category.Combat, KeyCode.Q)
        {
            Settings.Add(_fireRate);
        }
        
        public override void OnUpdate()
        {
            if (GameData.LocalPlayer == null || GameData.CurrentWeapon == null) return;

            GameData.CurrentWeapon.Fire();
        }
    }
}