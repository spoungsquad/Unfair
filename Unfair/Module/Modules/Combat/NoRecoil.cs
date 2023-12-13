using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Combat
{
    public class NoRecoil : Module
    {
        public NoRecoil() : base("NoRecoil", "Remove recoil", Category.Combat, KeyCode.L)
        {
            Enabled = true;
        }
        
        public override void OnUpdate()
        {
            if (GameData.CameraManager == null || GameData.CameraManager.TPCamera == null) return;
            
            // 4 fields referenced in vThirdPersonCamera.AddRecoil
            GameData.CameraManager.TPCamera.SetField("NLHDAMDEIOK", 0f);
            GameData.CameraManager.TPCamera.SetField("NAAICIOIOGN", 0f);
            GameData.CameraManager.TPCamera.SetField("EMDGHAADDMO", 0f);
            GameData.CameraManager.TPCamera.SetField("OMALGBDNEIF", Vector2.zero);
        }
    }
}