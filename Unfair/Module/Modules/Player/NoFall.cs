using UnityEngine;

namespace Unfair.Module.Modules.Player
{
    public class NoFall : Module
    {
        // Constructor
        public NoFall() : base("NoFall", "No fall damage", Category.Player, KeyCode.None)
        {
        }
        
        public override void OnUpdate()
        {
            PlayerController.LHFJFKJJKCG.JDHLKGBHMAD.SetFallDamageEnabled(true);
        }
        
        public override void OnDisable()
        {
            PlayerController.LHFJFKJJKCG.JDHLKGBHMAD.SetFallDamageEnabled(false);
        }
    }
}