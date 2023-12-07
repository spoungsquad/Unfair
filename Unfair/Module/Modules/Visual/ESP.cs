using System.Collections.Generic;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Visual
{
    public class ESP : Module
    {
        private readonly List<PlayerController> _players = new List<PlayerController>();

        public ESP() : base("ESP", "Allows you to see players through walls", Category.Visuals, KeyCode.K)
        {
            Enabled = true;
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

                // POJDIMMBOCO = Is bot
                var color = player.POJDIMMBOCO ? Color.yellow : Color.red;

                string name = player.photonView.Controller.NickName;

                // Get screen distance from head to feet
                var yDistance = Vector3.Distance(headPos, feetPos);
                var xDistance = yDistance / 2;

                Render.DrawBoxOutline(new Vector2(headPos.x - (xDistance / 2), Screen.height - headPos.y), xDistance, yDistance, color);

                float textWidth = GUI.skin.label.CalcSize(new GUIContent(name)).x;

                GUI.color = color;
                GUI.Label(new Rect(headPos.x - (textWidth / 2), Screen.height - headPos.y - 30, 150, 40), name);
            }
        }

        public override void OnUpdate()
        {
            _players.Clear();
            _players.AddRange(GameData.PlayerControllers);
        }
    }
}