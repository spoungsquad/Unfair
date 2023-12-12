using Photon.Pun;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Movement
{
    public class Spinbot : Module
    {
        private int i = 0;

        public Spinbot() : base("Spinbot", "Spins around", Category.Movement, KeyCode.G)
        {
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