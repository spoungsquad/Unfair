using UnityEngine;

namespace Unfair.Module.Modules.Building
{
    public class Instabreak : Module
    {
        public Instabreak() : base("Instabreak", "Breaks player built buildings instantly", Category.Building, KeyCode.L)
        {
            Enabled = true;
        }
        
        public override void OnUpdate()
        {
            PlayerBuildingManager.IsOneHitBuildings = true; 
        }
        
    }
}