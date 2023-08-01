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
            PlayerController.LHFJFKJJKCG.gameObject.transform.Rotate(0, i, 0);
            if (i > 360)
                i = 0;
        }
    }
}