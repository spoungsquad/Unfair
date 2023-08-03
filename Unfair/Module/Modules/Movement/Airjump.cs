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
            GameData.ThirdPersonController.isGrounded = true;
            GameData.ThirdPersonController.isJumping = false;
            GameData.ThirdPersonController.IsCrawling = false;
        }
    }
}