using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Combat
{
    public class NoRecoil : Module
    {
        public NoRecoil() : base("NoRecoil", "Removes recoil from your current weapon", Category.Combat, KeyCode.L)
        {
            Enabled = true;
        }
        
        public override void OnUpdate()
        {
            if (GameData.LocalPlayer == null || GameData.CurrentWeapon == null) return;

            // Doesn't work?
            GameData.CurrentWeaponData.Stats.StatsForLevel.RecoilForce = 0;
            GameData.CurrentWeaponData.Stats.StatsForLevel.RecoilDuration = 0;
        }
    }
}