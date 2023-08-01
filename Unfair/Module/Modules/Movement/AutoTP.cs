using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var players = Main.PlayerControllers.OrderBy(x => Vector3.Distance(x.transform.position, PlayerController.LHFJFKJJKCG.transform.position)).ToList();
            players.Remove(PlayerController.LHFJFKJJKCG);
            var target = players.FirstOrDefault();

            PlayerController.LHFJFKJJKCG.gameObject.transform.position = target.transform.position;
        }
    }
}