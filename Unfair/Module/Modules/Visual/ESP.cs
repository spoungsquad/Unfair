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
            foreach (PlayerController player in Main.PlayerControllers)
            {
                if (player.IsMine())
                    continue;
                Animator animator = player.GetComponent<Animator>();

                Transform headPos = animator.GetBoneTransform(HumanBodyBones.Head);

                Vector3 pos = Camera.main.WorldToScreenPoint(headPos.transform.position);
                
                if (pos.z < 0) continue;
                Color color = Color.white;

                GUI.color = color;
                
                // Get name 
                string name = player.photonView.Controller.NickName;

                GUI.Label(new Rect(pos.x, Screen.height - pos.y, 100, 20), name);
                //Render.DrawBoxGUI(new Rect(pos.x - 50, Screen.height - pos.y, 20, 100), color, 1f);
            }
        }
    }
}