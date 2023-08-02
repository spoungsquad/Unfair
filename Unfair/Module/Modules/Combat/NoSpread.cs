using System;
using JustPlay.Equipment;
using Unfair.Util;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Unfair.Module.Modules.Combat
{
    public class NoSpread : Module
    {
        public NoSpread() : base("NoSpread", "Removes spread", Category.Combat, KeyCode.L)
        {
            Enabled = true;
        }

        public override unsafe void OnGUI()
        {
        }
    }
}