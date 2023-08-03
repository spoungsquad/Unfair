using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Movement
{
    public class VClip : Module
    {
        public VClip() : base("VClip", "Allows you to clip through blocks", Category.Movement, KeyCode.DownArrow)
        {
        }

        public override void OnEnable()
        {
            GameData.LocalPlayer.gameObject.transform.position = new Vector3(GameData.LocalPlayer.transform.position.x,
                GameData.LocalPlayer.transform.position.y - 5, GameData.LocalPlayer.transform.position.z);
            
            // why
            // this.Enabled = false;
            // OnDisable();
            
            Toggle();
        }
    }
}