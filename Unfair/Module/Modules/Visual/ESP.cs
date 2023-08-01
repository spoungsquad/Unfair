using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Visual
{
    public class ESP : Module
    {
        // Constructor
        public ESP() : base("ESP", "Allows you to see players through walls", Category.Visuals, KeyCode.F6)
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
                var animator = player.GetComponent<Animator>();

                var headPos = animator.GetBoneTransform(HumanBodyBones.Head);

                var pos = Camera.main.WorldToScreenPoint(headPos.transform.position);
                
                if (pos.z < 0) continue;
                var color = Color.white;

                GUI.color = color;
                
                // Get name 
                var name = player.photonView.Controller.NickName;

                GUI.Label(new Rect(pos.x, Screen.height - pos.y, 100, 20), name);
                //Render.DrawBoxGUI(new Rect(pos.x - 50, Screen.height - pos.y, 20, 100), color, 1f);
            }
        }
    }
}