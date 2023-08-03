using System.Collections.Generic;
using System.Linq;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Movement
{
    public class AutoTP : Module
    {
        public AutoTP() : base("AutoTP", "Teleports you to the closest player", Category.Combat, KeyCode.P)
        {
        }

        public override void OnUpdate()
        {
            // Stolen from falash aimbote
            List<PlayerController> players = GameData.PlayerControllers.OrderBy(x => Vector3.Distance(x.transform.position, GameData.LocalPlayer.transform.position)).ToList();
            players.Remove(GameData.LocalPlayer);
            PlayerController target = players.FirstOrDefault();

            GameData.LocalPlayer.gameObject.transform.position = target.transform.position;
        }
    }
}