using System.Collections.Generic;
using System.Linq;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Combat
{
    public class AimAssist : Module
    {
        public AimAssist() : base("AimAssist", "Artificially improve your aim", Category.Combat, KeyCode.I)
        {
        }

        private const float maxDistanceFromCenter = 200f;
        
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
                var playerHeadScreenPos2 = new Vector2(playerHeadScreenPos.x, Screen.height - playerHeadScreenPos.y);
                var centerScreenPos = new Vector2(Screen.width / 2f, Screen.height / 2f);
                var distanceFromCenter = Vector2.Distance(playerHeadScreenPos2, centerScreenPos);
                if (distanceFromCenter > maxDistanceFromCenter) continue;
                
                playersInFov.Add(player);
            }

            return playersInFov;
        }

        private bool _isPlayerInFov = false;
        private Vector3 oldPos = Vector3.zero;
        // ReSharper disable Unity.PerformanceAnalysis
        public override void OnUpdate()
        {
            var playersInFov = GetPlayersInFov();
            _isPlayerInFov = playersInFov.Count > 0;
            if (!Input.GetKey(KeyCode.Mouse0)) return;
            if (playersInFov.Count == 0) return;
            
            var player = playersInFov.First();
            
            // Make the player's camera look at the player
            Animator animator = player.GetComponent<Animator>();
            Transform bone = animator.GetBoneTransform(HumanBodyBones.Head);
            
            
            Vector3 pos = GameData.CameraManager.TPCamera.transform.position;
            Vector3 targetPos = bone.position;
            Vector3 extrapolatedPos = targetPos + (targetPos - oldPos) * 2f;

            // Calculate the new rotation
            var newRotation = Quaternion.LookRotation(extrapolatedPos - pos);
            var oldRotation = GameData.CameraManager.TPCamera.transform.rotation;
            var rotation = Quaternion.Lerp(oldRotation, newRotation, Time.deltaTime * 100f);
            
            // Set the rotation of TP Camera
            GameData.CameraManager.SetCameraRotation(rotation.eulerAngles);
            
            this.oldPos = targetPos;
        }
        
        public override void OnGUI()
        {
            // Draw a circle in the center of the screen
            Color color = _isPlayerInFov ? Color.green : Color.red;
            Render.DrawCircle(new Vector2(Screen.width / 2f, Screen.height / 2f), maxDistanceFromCenter, color);
            
        }
    }
}