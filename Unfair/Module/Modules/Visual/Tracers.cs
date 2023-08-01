using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Visual
{
    public class Tracers : Module
    {
        // Constructor
        
        public Tracers() : base("Tracers", "Draws a line to players", Category.Visuals, KeyCode.F7)
        {
            Enabled = true;
        }

        public override void OnGUI()
        {
            // Loop through all playerControllers
            foreach (var player in Main.PlayerControllers)
            {
                if (player.IsMine())
                    continue;
                
                
                var pos = Camera.main.WorldToScreenPoint(player.transform.position);
                
                // Get center of screen
                var center = new Vector2(Screen.width / 2, Screen.height / 2);
                
                // Draw line
                Render.DrawLine(center, pos,  Color.white, 2f);
                
            }
        }
    }
}