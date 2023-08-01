using System.Linq;
using UnityEngine;

namespace Unfair.Module.Modules.Player
{
    public class Aimbot : Module
    {
        // Constructor
        public Aimbot() : base("Aimbot", "Automatically aims at the nearest player", Category.Player, KeyCode.F3)
        {
        }
        
        public PlayerController GetClosestPlayer()
        {
            PlayerController[] fish = Object.FindObjectsOfType(typeof(PlayerController)) as PlayerController[];
            if (fish.Length != 0)
            {
                PlayerController currentFish = fish[0];

                foreach (PlayerController nextFish in fish)
                {
                     
                    
                    if ((nextFish.transform.position - PlayerController.LHFJFKJJKCG.transform.position).sqrMagnitude <
                        (currentFish.transform.position - PlayerController.LHFJFKJJKCG.transform.position).sqrMagnitude || !nextFish.IsMine())
                    {
                        currentFish = nextFish;
                    }
                }
                return currentFish;
            }
            return null;
        }

        public override void OnUpdate()
        {   
            // Get nearest player

            var player = GetClosestPlayer();
            
            if (player == null)
                return;
            
            // Get camera 
            var camera = Camera.current;
                
            // Look at player
            camera.transform.LookAt(player.transform);
            
        }
    }
}