using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Combat
{
    public class Triggerbot : Module
    {
        public Triggerbot() : base("Triggerbot", "Automatically shoot at players", Category.Combat, KeyCode.None)
        {
        }
        
        public override void OnUpdate()
        {
            var hit = GameData.WeaponController.LKGOODIEFCN;
            if (hit.collider == null)
                return;
                
            if (hit.collider.gameObject == null)
                return;
                
            DebugConsole.Write(hit.collider.gameObject.name);
            DebugConsole.Write(hit.collider.gameObject.tag);
                
            if (hit.collider.gameObject.tag != "Player" && hit.collider.gameObject.tag != "AutoAim")
                return;
                    
            GameData.WeaponController.TryFireWeapon();
        }
    }
}