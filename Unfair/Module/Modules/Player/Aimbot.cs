using System.Collections.Generic;
using System.Linq;
using Unfair.Util;
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
                List<PlayerController> players = GameData.PlayerControllers.OrderBy(x => Vector3.Distance(x.transform.position, GameData.LocalPlayer.transform.position)).ToList();

                players.Remove(GameData.LocalPlayer);
            
                PlayerController player = players.FirstOrDefault();
                Camera camera = GameData.MainCamera;
                
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