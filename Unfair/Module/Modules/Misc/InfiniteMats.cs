using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Misc
{
    public class InfiniteMats : Module
    {
        public InfiniteMats() : base("InfiniteMats", "r u dumb mate", Category.Misc, KeyCode.Minus)
        {
            Enabled = true;
        }

        private bool _prev;
        
        public override void OnUpdate()
        {
            GameData.CurrentGameMode.IsBuildingAmmoUnlimited = true;
            if (GameData.LocalPlayer.PlayerBuildingManager.BuildingAmmo < 1000)
            {
                GameData.LocalPlayer.PlayerBuildingManager.BuildingAmmo = 1000;
            }
            if (GameData.LocalPlayer.PlayerBuildingManager.buildingManager.GetField<int>("OEOFDKOPCMN") < 1000)
            {
                GameData.LocalPlayer.PlayerBuildingManager.buildingManager.SetField("OEOFDKOPCMN", 1000);
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