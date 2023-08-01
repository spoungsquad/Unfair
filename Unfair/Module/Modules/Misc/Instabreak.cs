using UnityEngine;

namespace Unfair.Module.Modules.Misc
{
    public class Instabreak : Module
    {
        public Instabreak() : base("Instabreak", "Breaks player built buildings instantly", Category.Misc, KeyCode.L)
        {
            Enabled = true;
        }
        
        public override void OnUpdate()
        {
            PlayerBuildingManager.IsOneHitBuildings = true; 
        }
        
    }
}