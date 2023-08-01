using System.Linq;
using UnityEngine;

namespace Unfair.Module.Modules.Player
{
    public class Aimbot : Module
    {
        // Constructor
        public Aimbot() : base("Aimbot", "Automatically aims at the nearest player", Category.Player, KeyCode.Mouse1)
        {
        }

        public override void OnUpdate()
        {   
            
            // Sort players by distance
            var players = Main.PlayerControllers.OrderBy(x => Vector3.Distance(x.transform.position, PlayerController.LHFJFKJJKCG.transform.position)).ToList();

            players.Remove(PlayerController.LHFJFKJJKCG);
            
            var player = players.FirstOrDefault();
            var camera = Camera.main;
                
            // Get animator
            var animator = player.GetComponent<Animator>();
                
            // Get head position
            var headPos = animator.GetBoneTransform(HumanBodyBones.UpperChest);
                
            // Look at player
            camera.transform.LookAt(headPos);
        }
    }
}