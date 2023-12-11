using System.Collections.Generic;
using System.Linq;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Combat
{
    public class AimAssist : Module
    {
        public AimAssist() : base("AimAssist", "AimAssist", Category.Combat, KeyCode.I)
        {
        }

        public List<PlayerController> GetPlayersInFov()
        {
            var players = GameData.PlayerControllers
                .OrderBy(x => Vector3.Distance(x.transform.position, GameData.LocalPlayer.transform.position)).ToList();
            var localPlayer = GameData.LocalPlayer;
            players.Remove(localPlayer);

            var localPlayerCamera = GameData.MainCamera;

            var playersInFov = new List<PlayerController>();
            foreach (var player in players)
            {
                if (player.photonView.IsMine) continue;
                
                var playerHead = player.GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Head);
                var playerHeadScreenPos = localPlayerCamera.WorldToScreenPoint(playerHead.transform.position);
                if (playerHeadScreenPos.z < 0) continue;
                var playerHeadScreenPos2 = new Vector2(playerHeadScreenPos.x, Screen.height - playerHeadScreenPos.y);
                var distance = Vector2.Distance(new Vector2(Screen.width / 2f, Screen.height / 2f), playerHeadScreenPos2);
                if (distance < 200f)
                {
                    playersInFov.Add(player);
                }
            }

            return playersInFov;
        }
        
        public override void OnUpdate()
        {
            if (!Input.GetKey(KeyCode.Mouse1)) return;
            var playersInFov = GetPlayersInFov();
            if (playersInFov.Count == 0) return;
            var player = playersInFov.First();
            if (player == null) return;
            Animator animator = player.GetComponent<Animator>();
            Transform bone = animator.GetBoneTransform(HumanBodyBones.Chest);
            GameData.MainCamera.transform.LookAt(bone);
        }
    }
}