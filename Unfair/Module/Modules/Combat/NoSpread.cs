using UnityEngine;

namespace Unfair.Module.Modules.Combat
{
    public class NoSpread : Module
    {
        public NoSpread() : base("NoSpread", "Removes spread", Category.Combat, KeyCode.L)
        {
            Enabled = true;
        }

        public override void OnGUI()
        {
        }
    }
}