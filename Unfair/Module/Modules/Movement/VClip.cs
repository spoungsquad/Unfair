using Unfair.Config.Settings;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Movement
{
    public class VClip : Module
    {
        private NumberSetting _distance = new NumberSetting("Distance", "How far you clip", 5f, -100f, 100f);
        
        public VClip() : base("VClip", "Vertical clip", Category.Movement, KeyCode.DownArrow)
        {
            Settings.Add(_distance);
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