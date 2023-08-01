using UnityEngine;

namespace Unfair.Module.Modules.Movement
{
    public class Spinbot : Module
    {
        public Spinbot() : base("Spinbot", "Spins around", Category.Movement, KeyCode.G)
        {
        }
        
        // test
        int i = 0;
        public override void OnUpdate()
        {
            i++;
            PlayerController.LHFJFKJJKCG.gameObject.transform.Rotate(i, i, i);
            if (i > 360)
                i = 0;
        }
        
        public override void OnDisable()
        {
            
            PlayerController.LHFJFKJJKCG.gameObject.transform.rotation = Quaternion.identity;
        }
    }
}