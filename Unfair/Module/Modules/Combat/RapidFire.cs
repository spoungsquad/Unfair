using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Combat
{
    public class RapidFire : Module
    {
        public RapidFire() : base("RapidFire", "Shoots faster", Category.Combat, KeyCode.Q)
        {
        }
        
        public override void OnUpdate()
        {
            GameData.CurrentWeapon.Fire();
        }
    }
}