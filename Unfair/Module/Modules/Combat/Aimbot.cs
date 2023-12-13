using System.Linq;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Combat
{
    public class Aimbot : Module
    {
        // Constructor
        public Aimbot() : base("Aimbot", "Automatically aim at the nearest player", Category.Combat, KeyCode.None)
        {
        }
        
        private Vector3 oldPos = Vector3.zero;
        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                // Sort players by distance
                var players = GameData.PlayerControllers.OrderBy(x => Vector3.Distance(x.transform.position, GameData.LocalPlayer.transform.position)).ToList();
                players.Remove(GameData.LocalPlayer);

                var player = players.First();
                if (player == null) return;

                Animator animator = player.GetComponent<Animator>();
                Transform bone = animator.GetBoneTransform(HumanBodyBones.Head);

                Vector3 targetPos = bone.position;
                Vector3 extrapolatedPos = targetPos + (targetPos - oldPos) * 2f;
                
                GameData.MainCamera.transform.LookAt(extrapolatedPos);
                oldPos = targetPos;
            }
        }
    }
}