using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Combat
{
    public class InfiniteRange : Module
    {
        public InfiniteRange() : base("InfiniteRange", "Infinite range", Category.Combat, KeyCode.L)
        {
            Enabled = true;
        }
        
        public override void OnUpdate()
        {
            if (GameData.LocalPlayer == null || GameData.CurrentWeapon == null) return;

            GameData.CurrentWeaponData.Stats.Range = 1000000;
        }
    }
}