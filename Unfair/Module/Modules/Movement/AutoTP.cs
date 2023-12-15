using System.Collections.Generic;
using System.Linq;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Movement
{
    public class AutoTP : Module
    {
        public AutoTP() : base("AutoTP", "Teleport to nearby players", Category.Combat, KeyCode.P)
        {
        }

        public override void OnUpdate()
        {
            // Stolen from falash aimbote
            List<PlayerController> players = GameData.PlayerControllers.OrderBy(x => Vector3.Distance(x.transform.position, GameData.LocalPlayer.transform.position)).ToList();
            players.Remove(GameData.LocalPlayer);
            PlayerController target = players.FirstOrDefault();
            if (target == null) return;

            GameData.LocalPlayer.transform.position = target.transform.position;
        }
    }
}