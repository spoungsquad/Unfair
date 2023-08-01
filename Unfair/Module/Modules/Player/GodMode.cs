using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Unfair.Module.Modules.Player
{
    public class GodMode : Module
    {
        public GodMode() : base("GodMode", "Be invincible to all damage", Category.Player, KeyCode.F9)
        {
        }

        public override void OnUpdate()
        {
            if (!PlayerController.LHFJFKJJKCG.JDHLKGBHMAD.GDGOFAMHGPF)
            {
                PlayerController.LHFJFKJJKCG.JDHLKGBHMAD.SetPlayerImmunity(true);
            }
        }

        public override void OnDisable()
        {
            PlayerController.LHFJFKJJKCG.JDHLKGBHMAD.SetPlayerImmunity(false);
        }
    }
}