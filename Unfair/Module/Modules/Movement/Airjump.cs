using Invector.CharacterController;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Movement
{
    public class Airjump : Module
    {
        // Constructor
        public Airjump() : base("Airjump", "Jump midair", Category.Movement, KeyCode.F5)
        {
        }
        
        public override void OnUpdate()
        {
            if (GameData.LocalPlayer is null || GameData.ThirdPersonController is null)
                return;
            GameData.ThirdPersonController.isGrounded = true;
            GameData.ThirdPersonController.isJumping = false;
            GameData.ThirdPersonController.IsCrawling = false;
        }
    }
}