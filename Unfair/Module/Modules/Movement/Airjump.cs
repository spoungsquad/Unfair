using Invector.CharacterController;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Movement
{
    public class Airjump : Module
    {
        // Constructor
        public Airjump() : base("Airjump", "Allows you to jump in midair", Category.Movement, KeyCode.F5)
        {
        }
        
        public override void OnUpdate()
        {
            
            var thirdPersonController =
                PrivateAccess.GetProp<vThirdPersonController>(PlayerController.LHFJFKJJKCG, "_thirdPersonController");

            
            thirdPersonController.isGrounded = true;
            thirdPersonController.isJumping = false;
            thirdPersonController.IsCrawling = false;
        }
    }
}