using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Combat
{
    public class NoRecoil : Module
    {
        public NoRecoil() : base("NoRecoil", "Removes recoil from your current weapon", Category.Combat, KeyCode.L)
        {
            Enabled = true;
        }
        
        public override void OnUpdate()
        {
            // 4 fields in vThirdPersonCamera.AddRecoil
            GameData.CameraManager.TPCamera.SetField("NLHDAMDEIOK", 0f);
            GameData.CameraManager.TPCamera.SetField("NAAICIOIOGN", 0f);
            GameData.CameraManager.TPCamera.SetField("EMDGHAADDMO", 0f);
            GameData.CameraManager.TPCamera.SetField("OMALGBDNEIF", Vector2.zero);
        }
    }
}