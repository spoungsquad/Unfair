using System;
using Invector.CharacterController;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Visual
{
    public class ESP : Module
    {
        private PlayerController[] _players = Array.Empty<PlayerController>();
        private int _count;
        // Constructor
        public ESP() : base("ESP", "Allows you to see players through walls", Category.Visuals, KeyCode.F6)
        {
            Enabled = true;
        }

        public override void OnGUI()
        {
            if (_count++ % 60 == 0)
            {
                _players = GameData.PlayerControllers;
                _count = 0;
            }
            // Loop through all playerControllers
            foreach (PlayerController player in _players)
            {
                if (player.IsMine())
                    continue;
                Animator animator = player.GetField<vThirdPersonController>("_thirdPersonController").animator; //player.GetComponent<Animator>();

                Vector3 pos = animator.GetBoneTransform(HumanBodyBones.Head).transform.position;

                Vector3 headPos = GameData.MainCamera.WorldToScreenPoint(pos + new Vector3(0, 0.25f, 0));
                Vector3 feetPos = GameData.MainCamera.WorldToScreenPoint(pos - new Vector3(0, 1.5f, 0));
                
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