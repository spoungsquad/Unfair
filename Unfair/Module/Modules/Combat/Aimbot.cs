using System.Collections.Generic;
using System.Linq;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Player
{
    public class Aimbot : Module
    {
        // Constructor
        public Aimbot() : base("Aimbot", "Automatically aims at the nearest player", Category.Combat, KeyCode.None)
        {
            Enabled = true;
        }

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
                Transform bone = animator.GetBoneTransform(HumanBodyBones.Chest);
                GameData.MainCamera.transform.LookAt(bone);
            }
        }
    }
}