using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Building
{
    public class InfiniteMats : Module
    {
        private bool _prev;

        public InfiniteMats() : base("InfiniteMats", "Infinite building materials", Category.Building, KeyCode.Minus)
        {
        }

        public override void OnDisable()
        {
            GameData.CurrentGameMode.IsBuildingAmmoUnlimited = _prev;
        }

        public override void OnEnable()
        {
            _prev = GameData.CurrentGameMode.IsBuildingAmmoUnlimited;
        }

        public override void OnUpdate()
        {
            if (GameData.LocalPlayer == null) return;

            GameData.CurrentGameMode.IsBuildingAmmoUnlimited = true;
            if (GameData.LocalPlayer.PlayerBuildingManager.BuildingAmmo < 1000)
            {
                GameData.LocalPlayer.PlayerBuildingManager.BuildingAmmo = 1000;
            }
            if (GameData.LocalPlayer.PlayerBuildingManager.buildingManager.GetField<int>("KGANGDMMEAD") < 1000)
            {
                GameData.LocalPlayer.PlayerBuildingManager.buildingManager.SetField("KGANGDMMEAD", 1000);
            }
        }
    }
}