using Photon.Pun;
using System.Collections.Generic;
using System.Linq;
using Unfair.Config.Settings;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Combat
{
    public class Aimbot : Module
    {
        private readonly BoolSetting _autoFire =
            new BoolSetting("Auto fire", "Automatically fire when aiming at a player", true);

        private readonly List<PlayerController> _players = new List<PlayerController>();

        private readonly BoolSetting _silentAim =
                    new BoolSetting("Silent aim", "Hide your aimbot (aka magic bullet)", false);

        private readonly ModeSetting<TargetMode> _targetMode =
                            new ModeSetting<TargetMode>("Target mode", "How to select targets", TargetMode.Distance);

        private readonly BoolSetting _targetVisible =
            new BoolSetting("Target visible", "Only target players that are visible", false);

        private Vector3 _oldPos = Vector3.zero;

        //TODO: KeybindSetting
        public Aimbot() : base("Aimbot", "Automatically aim at the nearest player", Category.Combat, KeyCode.None)
        {
            Settings.Add(_targetMode);
            Settings.Add(_targetVisible);
            Settings.Add(_autoFire);
            Settings.Add(_silentAim);
        }

        private enum TargetMode
        {
            Distance,
            NearCrosshair,
            Cycle,
            Rank
        }

        public override void OnUpdate()
        {
            if (GameData.LocalPlayer is null) return;
            if (GameData.CurrentWeapon is null) return;

            // GetKeyDown is used to prevent the list from being updated every frame!
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                _players.Clear();
                _players.AddRange(GameData.PlayerControllers);
                _players.Remove(GameData.LocalPlayer);
            }

            if (_players.Count == 0) return;

            PlayerController target = null;

            switch (_targetMode.Value)
            {
                case TargetMode.Distance:
                    target = _players.OrderBy(x => Vector3.Distance(x.transform.position, GameData.LocalPlayer.transform.position)).First();
                    break;

                case TargetMode.NearCrosshair:
                    Vector3 screenPos = GameData.MainCamera.WorldToScreenPoint(GameData.LocalPlayer.transform.position);
                    Vector3 crosshairPos = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);

                    target = _players.OrderBy(x => Vector3.Distance(GameData.MainCamera.WorldToScreenPoint(x.transform.position), crosshairPos)).First();
                    break;

                case TargetMode.Cycle:
                    target = _players[Random.Range(0, _players.Count)];
                    break;

                case TargetMode.Rank:
                    target = _players.OrderBy(x => x.photonView.Controller.RankXP).First();
                    break;
            }

            if (target == null) return;

            Animator animator = target.GetComponent<Animator>();
            Transform bone = animator.GetBoneTransform(HumanBodyBones.Head);

            Vector3 targetPos = bone.position;
            Vector3 extrapolatedPos = targetPos + (targetPos - _oldPos) * 2f;
            _oldPos = targetPos;

            if (_silentAim.Value)
            {
                GameData.CurrentWeapon.SetField("_weaponFireOrigin", extrapolatedPos);
            }
            else GameData.MainCamera.transform.LookAt(extrapolatedPos);

            if (_autoFire.Value)
            {
                for (int i = 0; i < 4; i++)
                {
                    GameData.CurrentWeapon.Fire();
                }
            }
        }
    }
}