using Unfair.Config.Settings;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Movement
{
    public class VClip : Module
    {
        private readonly NumberSetting _distanceY = new NumberSetting("Distance", "Distance to teleport up/down", -5, -100, 100);

        public VClip() : base("VClip", "Vertical clip", Category.Movement, KeyCode.DownArrow)
        {
            Settings.Add(_distanceY);
        }

        public override void OnEnable()
        {
            GameData.LocalPlayer.gameObject.transform.position = new Vector3(GameData.LocalPlayer.transform.position.x,
                GameData.LocalPlayer.transform.position.y + _distanceY.Value, GameData.LocalPlayer.transform.position.z);
            Toggle();
        }
    }
}