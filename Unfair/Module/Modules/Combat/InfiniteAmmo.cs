using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Combat
{
    public class InfiniteAmmo : Module
    {
        public InfiniteAmmo() : base("InfiniteAmmo", "Infinite ammo", Category.Combat, KeyCode.L)
        {
            Enabled = true;
        }

        public override void OnUpdate()
        {
            GameData.CurrentWeapon.SetCurrentMagazineAmount(10000);
            
            // Get building manager
            GameData.LocalPlayer.PlayerBuildingManager.AddBuildingAmmo(10000);
            
            
        }
    }
}