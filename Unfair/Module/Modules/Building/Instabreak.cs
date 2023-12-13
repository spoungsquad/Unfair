using UnityEngine;

namespace Unfair.Module.Modules.Building
{
    public class Instabreak : Module
    {
        public Instabreak() : base("Instabreak", "Instant break speed", Category.Building, KeyCode.L)
        {
        }
        
        public override void OnUpdate()
        {
            PlayerBuildingManager.IsOneHitBuildings = true; 
        }
        
        public override void OnDisable()
        {
            PlayerBuildingManager.IsOneHitBuildings = false;
        }
    }
}