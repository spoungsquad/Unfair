using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Combat
{
    public class InfiniteAmmo : Module
    {
        public InfiniteAmmo() : base("InfiniteAmmo", "Infinite ammo", Category.Combat, KeyCode.L)
        {
        }

        public override void OnUpdate()
        {
            if (GameData.LocalPlayer == null || GameData.CurrentWeapon == null) return;

            GameData.CurrentWeapon.SetCurrentMagazineAmount(10000);
            // Get building manager
            GameData.LocalPlayer.PlayerBuildingManager.AddBuildingAmmo(10000);
        }
    }
}