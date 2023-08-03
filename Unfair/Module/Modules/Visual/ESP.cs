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
            foreach (PlayerController player in GameData.PlayerControllers)
            {
                if (player.IsMine())
                    continue;
                Animator animator = player.GetComponent<Animator>();

                Transform head = animator.GetBoneTransform(HumanBodyBones.Head);

                Vector3 headPos = Camera.main.WorldToScreenPoint(head.transform.position + new Vector3(0, 0.25f, 0));
                Vector3 feetPos = Camera.main.WorldToScreenPoint(head.transform.position - new Vector3(0, 1.5f, 0));
                
                if (headPos.z < 0) continue;
                if (feetPos.z < 0) continue; 
                Color color = Color.red;

                GUI.color = color;
                
                // Get name 
                string name = player.photonView.Controller.NickName;
                
                // Get screen distance from head to feet
                float yDistance = Vector3.Distance(headPos, feetPos);
                float xDistance = yDistance / 2;
                
                // Get box rect
                Rect rect = new Rect(headPos.x - (xDistance / 2), Screen.height - headPos.y, xDistance, yDistance);
                
                Render.DrawBoxGUI(rect, color, 2f);
                // Draw name under the middle of the box
                
                float textWidth = GUI.skin.label.CalcSize(new GUIContent(name)).x;
                
                // if player is bot then draw name as yellow
                GUI.color = player.JPHLECKOAAN ? Color.yellow : Color.red;
                
                GUI.Label(new Rect(rect.x + (rect.width / 2) - (textWidth / 2), rect.y + rect.height, 100, 20), name);
            }
        }
    }
}