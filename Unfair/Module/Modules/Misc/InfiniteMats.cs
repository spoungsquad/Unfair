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
            FPGPJAODPFL.LLMMGEMHPOA.IsBuildingAmmoUnlimited = true;
            if (PlayerController.LHFJFKJJKCG.PlayerBuildingManager.BuildingAmmo < 1000)
            {
                PlayerController.LHFJFKJJKCG.PlayerBuildingManager.BuildingAmmo = 1000;
            }
            if (PlayerController.LHFJFKJJKCG.PlayerBuildingManager.buildingManager.GetField<int>("OEOFDKOPCMN") < 1000)
            {
                PlayerController.LHFJFKJJKCG.PlayerBuildingManager.buildingManager.SetField("OEOFDKOPCMN", 1000);
            }
        }
        
        public override void OnEnable()
        {
            _prev = FPGPJAODPFL.LLMMGEMHPOA.IsBuildingAmmoUnlimited;
        }
        
        public override void OnDisable()
        {
            FPGPJAODPFL.LLMMGEMHPOA.IsBuildingAmmoUnlimited = _prev;
        }
        
    }
}