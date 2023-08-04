using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Building
{
    public class InfiniteMats : Module
    {
        public InfiniteMats() : base("InfiniteMats", "r u dumb mate", Category.Building, KeyCode.Minus)
        {
            Enabled = false;
        }

        private bool _prev;
        
        public override void OnUpdate()
        {
            if (GameData.LocalPlayer == null) return;

            GameData.CurrentGameMode.IsBuildingAmmoUnlimited = true;
            if (GameData.LocalPlayer.PlayerBuildingManager.BuildingAmmo < 1000)
            {
                GameData.LocalPlayer.PlayerBuildingManager.BuildingAmmo = 1000;
            }
            if (GameData.LocalPlayer.PlayerBuildingManager.buildingManager.GetField<int>("PJELDKBINAK") < 1000)
            {
                GameData.LocalPlayer.PlayerBuildingManager.buildingManager.SetField("PJELDKBINAK", 1000);
            }
        }
        
        public override void OnEnable()
        {
            _prev = GameData.CurrentGameMode.IsBuildingAmmoUnlimited;
        }
        
        public override void OnDisable()
        {
            GameData.CurrentGameMode.IsBuildingAmmoUnlimited = _prev;
        }
        
    }
}