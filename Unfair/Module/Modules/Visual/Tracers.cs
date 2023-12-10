using System.Collections.Generic;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Visual
{
    public class Tracers: Module
    {
        private readonly List<PlayerController> _players = new List<PlayerController>();


        // Constructor
        public Tracers() : base("Tracers", "Draws a line to players", Category.Visuals, KeyCode.None)
        {
            Enabled = false;
        }

        // Called every frame
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

                // Get screen distance from head to feet
                var yDistance = Vector3.Distance(headPos, feetPos);
                var xDistance = yDistance / 2;
                
                Render.DrawLine(new Vector2(headPos.x - (xDistance / 2), Screen.height - headPos.y), new Vector2(Screen.width / 2f, Screen.height), color);
            }
        }
        
        

        public override void OnUpdate()
        {
            _players.Clear();
            _players.AddRange(GameData.PlayerControllers);
        }
    }
}