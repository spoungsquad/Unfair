using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Movement
{
    public class Spinbot : Module
    {
        public Spinbot() : base("Spinbot", "Spins around", Category.Movement, KeyCode.G)
        {
        }
        
        
        int i = 0;
        public override void OnUpdate()
        {
            i++;
            GameData.LocalPlayer.gameObject.transform.Rotate(i, i, i);
            if (i > 360)
                i = 0;
        }
        
        public override void OnDisable()
        {
            GameData.LocalPlayer.gameObject.transform.rotation = Quaternion.identity;
        }
    }
}