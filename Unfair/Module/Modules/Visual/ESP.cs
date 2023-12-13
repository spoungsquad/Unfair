using System.Collections.Generic;
using System.Linq;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Visual
{
    public class ESP : Module
    {
        private List<PlayerController> _players = new List<PlayerController>();

        public ESP() : base("ESP", "Allows you to see players through walls", Category.Visuals, KeyCode.K)
        {
        }

        public void RenderBoneFromTransform(Transform bone)
        {
            Vector2 boneStartPos = Camera.main.WorldToScreenPoint(bone.position);
            Vector2 boneEndPos = Camera.main.WorldToScreenPoint(bone.parent.position);
            
            // Subtract y pos from screen height to flip the y axis
            boneStartPos.y = Screen.height - boneStartPos.y;
            boneEndPos.y = Screen.height - boneEndPos.y;
                
            Render.DrawLine(boneEndPos, boneStartPos, Color.white);
        }
        
        public override void OnGUI()
        {
            foreach (var player in _players)
            {
                if (player.IsMine())
                    continue;

                Animator animator = player.GetComponent<Animator>();

                Transform head = animator.GetBoneTransform(HumanBodyBones.Head);
                Transform feet = animator.GetBoneTransform(HumanBodyBones.LeftFoot);
                Transform feet2 = animator.GetBoneTransform(HumanBodyBones.RightFoot);

                // avg both feet
                var bottomPos = new Vector3((feet.position.x + feet2.position.x) / 2, (feet.position.y + feet2.position.y) / 2, (feet.position.z + feet2.position.z) / 2);

                var headPos = Camera.main.WorldToScreenPoint(head.transform.position + new Vector3(0, 0.25f, 0));
                var feetPos = Camera.main.WorldToScreenPoint(bottomPos);

                if (headPos.z < 0 || feetPos.z < 0) continue;

                // FGOFLOEPNHI = Is bot
                var color = player.FGOFLOEPNHI ? Color.yellow : Color.red;

                string name = player.photonView.Controller.NickName;

                // Get screen distance from head to feet
                var yDistance = Vector3.Distance(headPos, feetPos);
                var xDistance = yDistance / 2;

                
                Rect rect = new Rect(headPos.x - xDistance / 2, Screen.height - headPos.y, xDistance, yDistance);
                
                // Draw box
                Render.FillRect(rect, new Color(30 / 255f, 30/ 255f, 30/ 255f, 30/ 255f));
                Render.DrawRect(rect, color);


                RenderBoneFromTransform(animator.GetBoneTransform(HumanBodyBones.UpperChest));
                RenderBoneFromTransform(animator.GetBoneTransform(HumanBodyBones.Chest));
                RenderBoneFromTransform(animator.GetBoneTransform(HumanBodyBones.Spine));
                RenderBoneFromTransform(animator.GetBoneTransform(HumanBodyBones.Head));
                RenderBoneFromTransform(animator.GetBoneTransform(HumanBodyBones.LeftUpperArm));
                RenderBoneFromTransform(animator.GetBoneTransform(HumanBodyBones.LeftLowerArm));
                RenderBoneFromTransform(animator.GetBoneTransform(HumanBodyBones.LeftHand));
                RenderBoneFromTransform(animator.GetBoneTransform(HumanBodyBones.RightUpperArm));
                RenderBoneFromTransform(animator.GetBoneTransform(HumanBodyBones.RightLowerArm));
                RenderBoneFromTransform(animator.GetBoneTransform(HumanBodyBones.RightHand));
                RenderBoneFromTransform(animator.GetBoneTransform(HumanBodyBones.LeftUpperLeg));
                RenderBoneFromTransform(animator.GetBoneTransform(HumanBodyBones.LeftLowerLeg));
                RenderBoneFromTransform(animator.GetBoneTransform(HumanBodyBones.LeftFoot));
                RenderBoneFromTransform(animator.GetBoneTransform(HumanBodyBones.RightUpperLeg));
                RenderBoneFromTransform(animator.GetBoneTransform(HumanBodyBones.RightLowerLeg));
                RenderBoneFromTransform(animator.GetBoneTransform(HumanBodyBones.RightFoot));
                
                
                
                
                
                float textWidth = GUI.skin.label.CalcSize(new GUIContent(name)).x;

                GUI.color = color;
                GUI.Label(new Rect(headPos.x - (textWidth / 2), Screen.height - headPos.y - 20, 150, 40), name);
            }
        }

        public override void OnUpdate()
        {
            _players = GameData.PlayerControllers.ToList();
        }
    }
}