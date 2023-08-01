using UnityEngine;

namespace Unfair.Module.Modules.Movement
{
    public class Fly : Module
    {
        // Constructor
        public Fly() : base("Fly", "Allows you to fly around the map", Category.Movement, KeyCode.F4)
        {
        }
        
        public override void OnEnable()
        {
            PlayerController.LHFJFKJJKCG.SetGodMode(true);
        }
        
        public override void OnDisable()
        {
            PlayerController.LHFJFKJJKCG.SetGodMode(false);
        }
    }
}