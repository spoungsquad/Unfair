using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Unfair.Module.Modules.Player
{
    public class Aimbot : Module
    {
        // Constructor
        public Aimbot() : base("Aimbot", "Automatically aims at the nearest player", Category.Player, KeyCode.None)
        {
            Enabled = true;
        }

        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                
                // Sort players by distance
                List<PlayerController> players = Main.PlayerControllers.OrderBy(x => Vector3.Distance(x.transform.position, PlayerController.LHFJFKJJKCG.transform.position)).ToList();

                players.Remove(PlayerController.LHFJFKJJKCG);
            
                PlayerController player = players.FirstOrDefault();
                Camera camera = Camera.main;
                
                // Get animator
                Animator animator = player.GetComponent<Animator>();
                
                // Get head position
                Transform headPos = animator.GetBoneTransform(HumanBodyBones.UpperChest);
                
                // Look at player
                camera.transform.LookAt(headPos);
            }
        }
    }
}