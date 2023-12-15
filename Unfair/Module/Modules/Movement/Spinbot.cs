using Photon.Pun;
using Unfair.Config.Settings;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Movement
{
    public class Spinbot : Module
    {
        private NumberSetting _speed = new NumberSetting("Speed", "How fast you spin", 1f, 0f, 10f);
        private BoolSetting _spinX = new BoolSetting("Spin on X", "Whether or not to spin on the X axis", true);
        private BoolSetting _spinY = new BoolSetting("Spin on Y", "Whether or not to spin on the Y axis", true);
        private BoolSetting _spinZ = new BoolSetting("Spin on Z", "Whether or not to spin on the Z axis", true);
        
        private int i = 0;

        public Spinbot() : base("Spinbot", "Spin around", Category.Movement, KeyCode.G)
        {
            Settings.Add(_speed);
            Settings.Add(_spinX);
            Settings.Add(_spinY);
            Settings.Add(_spinZ);
        }

        public override void OnDisable()
        {
            GameData.LocalPlayer.gameObject.transform.rotation = Quaternion.identity;
        }

        public override void OnUpdate()
        {
            if (GameData.LocalPlayer is null) return;

            i++;
            GameData.LocalPlayer.gameObject.transform.Rotate(i, i, i);
            if (i > 360)
                i = 0;
        }
    }
}