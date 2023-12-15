using System.Linq;
using Unfair.Config.Settings;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Combat
{
    public class Aimbot : Module
    {
        private enum TargetMode
        {
            Distance,
            NearCrosshair,
            Cycle,
            Rank
        }
        
        private ModeSetting<TargetMode> _targetMode = 
            new ModeSetting<TargetMode>("Target mode", "How to select targets", TargetMode.Distance);
        
        private BoolSetting _targetVisible = 
            new BoolSetting("Target visible", "Only target players that are visible", false);
        
        private BoolSetting _autoFire = 
            new BoolSetting("Auto fire", "Automatically fire when aiming at a player", false);
        
        private BoolSetting _silentAim = 
            new BoolSetting("Silent aim", "Hide your aimbot (aka magic bullet)", false);
        
        private Vector3 _oldPos = Vector3.zero;
        
        // Constructor
        public Aimbot() : base("Aimbot", "Automatically aim at the nearest player", Category.Combat, KeyCode.None)
        {
            Settings.Add(_targetMode);
            Settings.Add(_targetVisible);
            Settings.Add(_autoFire);
            Settings.Add(_silentAim);
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
                Transform bone = animator.GetBoneTransform(HumanBodyBones.Head);

                Vector3 targetPos = bone.position;
                Vector3 extrapolatedPos = targetPos + (targetPos - _oldPos) * 2f;
                
                GameData.MainCamera.transform.LookAt(extrapolatedPos);
                _oldPos = targetPos;
            }
        }
    }
}